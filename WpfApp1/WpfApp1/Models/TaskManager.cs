using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp1.Exceptions;

namespace WpfApp1.Models
{
    public class TaskManager
    {
        private readonly ICollection<Task> _tasks;
        public TaskManager()
        {
            _tasks = new List<Task>();
        }

        public IEnumerable<Task> GetTaskForUser(string username)
        {
            return _tasks.Where(x => x.UserID == username);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        public void AddTask(Task task)
        {
            foreach(Task existingTask in _tasks)
            {
                if(existingTask.Conflicts(task))
                {
                    throw new TaskConflictException(existingTask,task);
                }
            }
            _tasks.Add(task);
        }
    }
}
