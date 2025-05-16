using System;
using System.Collections.Generic;
using TaskManager.Model;

namespace TaskManager.View
{
    public interface ITaskView
    {
        string TaskDescription { get; }
        event EventHandler AddTaskClicked;
        void UpdateTaskList(IEnumerable<TaskItem> tasks);
    }
}