using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class TaskViewModel : ViewModelBase
    {
        private readonly Task _task;
        public string TaskID => _task.TaskID;
        public string TaskName => _task.TaskName;
        public DateTime DateCreated => _task.DateCreated.Date;
        public string Description => _task.Description;
        public string Status => _task.Status;
        public string Type => _task.Type;
        public string UserID => _task.UserID;
        public DateTime NextAction => _task.NextAction; 

        public TaskViewModel(Task task)
        {
            _task = task;
        }
    }
}
