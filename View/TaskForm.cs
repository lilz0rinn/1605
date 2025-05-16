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
            if (_isUpdatingList) return; // не реагуємо під час оновлення

            if (e.Item.Tag is TaskItem task)
            {
                task.ToggleCompleted();
            }
        }
        private void InitializeComponent()
        {
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDescription.Location = new System.Drawing.Point(12, 12);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 49);
            this.txtDescription.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(276, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 48);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Додати завдання";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // lstTasks
            // 
            this.lstTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTasks.CheckBoxes = true;
            this.lstTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstTasks.HideSelection = false;
            this.lstTasks.Location = new System.Drawing.Point(12, 123);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(425, 294);
            this.lstTasks.TabIndex = 2;
            this.lstTasks.UseCompatibleStateImageBehavior = false;
            this.lstTasks.View = System.Windows.Forms.View.List;
            // 
            // TaskForm
            // 
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(449, 427);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Name = "TaskForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}