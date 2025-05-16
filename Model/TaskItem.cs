using System;

namespace TaskManager.Model
{
    public delegate void StatusChangedEventHandler(object sender, EventArgs e);

    public class TaskItem
    {
        public string Description { get; }
        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            private set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnStatusChanged();
                }
            }
        }

        public event StatusChangedEventHandler StatusChanged;

        public TaskItem(string description)
        {
            Description = description;
            _isCompleted = false;
        }

        public void ToggleCompleted()
        {
            IsCompleted = !IsCompleted;
        }

        protected virtual void OnStatusChanged()
        {
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}