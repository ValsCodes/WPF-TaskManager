using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class TaskViewModel : ViewModelBase
    {
        private readonly Task _task;
        public string TaskID => _task.TaskID.ToString();
        public string TaskName => _task.TaskName;
        public string DateCreated => _task.DateCreated.Date.ToString("d");
        public string Description => _task.Description;
        public string Status => _task.Status;
        public string Type => _task.Type;
        public string Assigned => _task.Assigned;
        public string NextAction => _task.NextAction.ToString("d");

        public TaskViewModel(Task task)
        {
            _task = task;
        }

    }
}
