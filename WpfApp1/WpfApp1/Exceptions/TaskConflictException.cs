using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using WpfApp1.Models;


namespace WpfApp1.Exceptions
{
    public class TaskConflictException : Exception
    {
        public Task ExistingTask { get; }
        public Task IncomingTask { get; }
        public TaskConflictException(Task existingTask, Task incomingTask)
        {
            ExistingTask = existingTask;
            IncomingTask = incomingTask;
        }

        public TaskConflictException(string message, Task existingTask, Task incomingTask) : base(message)
        {
            ExistingTask = existingTask;
            IncomingTask = incomingTask;
        }

        public TaskConflictException(string message, Exception innerException, Task existingTask, Task incomingTask) : base(message, innerException)
        {
            ExistingTask = existingTask;
            IncomingTask = incomingTask;
        }
    }
}
    