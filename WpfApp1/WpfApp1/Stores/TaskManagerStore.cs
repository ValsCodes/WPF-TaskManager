using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Stores
{
    public  class TaskManagerStore
    {
        private readonly TaskManager _taskManager;
        private readonly List<Models.Task> _tasks;
        public IEnumerable<Models.Task> Tasks => _tasks;

        public TaskManagerStore(TaskManager taskManager)
        {
            _taskManager = taskManager;
            _tasks = new List<Models.Task>();
        }

        public async System.Threading.Tasks.Task Load(TaskManager taskmanager)
        {
            IEnumerable<Models.Task> tasks = await taskmanager.GetAllTasks();
            _tasks.Clear();
            _tasks.AddRange(tasks);
        }
    }
}
