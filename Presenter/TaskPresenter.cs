using System;
using System.Collections.Generic;
using TaskManager.Model;
using TaskManager.View;

namespace TaskManager.Presenter
{
    public class TaskPresenter
    {
        private readonly ITaskView _view;
        private readonly List<TaskItem> _tasks = new List<TaskItem>();


        public TaskPresenter(ITaskView view)
        {
            _view = view;
            _view.AddTaskClicked += OnAddTaskClicked;
        }

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_view.TaskDescription))
            {
                var task = new TaskItem(_view.TaskDescription);

                task.StatusChanged += (s, a) => _view.UpdateTaskList(_tasks);

                _tasks.Add(task);
                _view.UpdateTaskList(_tasks);
            }
        }
    }
}