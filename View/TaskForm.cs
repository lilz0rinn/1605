using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskManager.Model;

namespace TaskManager.View
{
    public partial class TaskForm : Form, ITaskView
    {
        private Button btnAdd;
        private ListView lstTasks;
        private TextBox txtDescription;

        public TaskForm()
        {
            InitializeComponent();
            btnAdd.Click += (s, e) => AddTaskClicked?.Invoke(this, EventArgs.Empty);
            lstTasks.ItemChecked += lstTasks_ItemChecked;
        }

        public string TaskDescription => txtDescription.Text;

        public event EventHandler AddTaskClicked;

        private bool _isUpdatingList = false;

        public void UpdateTaskList(IEnumerable<TaskItem> tasks)
        {
            _isUpdatingList = true;

            lstTasks.Items.Clear();
            foreach (var task in tasks)
            {
                var item = new ListViewItem(task.Description)
                {
                    Checked = task.IsCompleted,
                    Tag = task
                };
                lstTasks.Items.Add(item);
            }

            _isUpdatingList = false;
        }

        private void lstTasks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_isUpdatingList) return;

            if (e.Item.Tag is TaskItem task)
            {
                task.ToggleCompleted();
            }
        }

        }
    }
}
