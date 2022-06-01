﻿using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        private readonly Task _task;
        public string TaskName => _task.TaskName;
        public DateTime DateCreated => _task.DateCreated.Date;
        public string Description => _task.Description;
        public string Status => _task.Status;
        public string Type => _task.Type;
        public string Assigned => _task.Assigned;
        public DateTime NextAction => _task.NextAction;

        public TaskViewModel(Task task)
        {
            _task = task;
        }

    }
}
