using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Exceptions;
using WpfApp1.Service;
using WpfApp1.Service.TaskConflictValidators;
using WpfApp1.Service.TaskProviders;

namespace WpfApp1.Models
{
    public class TaskManager
    {
        private readonly ITaskProvider _taskProvider;
        private readonly ITaskCreator _taskCreator;
        private readonly ITaskConflictValidator _taskConflictValidator;

        public TaskManager(ITaskProvider taskProvider, ITaskCreator taskCreator, ITaskConflictValidator taskConflictValidator)
        {
            _taskProvider = taskProvider;
            _taskCreator = taskCreator;
            _taskConflictValidator = taskConflictValidator;
        }

        /*
        public  IEnumerable<Task> GetTaskForUser(string username)
        {
            return _tasks.Where(x => x.Assigned == username);
        }
        */
        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _taskProvider.GetAllTasks();
        }


        public async System.Threading.Tasks.Task AddTask(Models.Task task)
        {
            /*
            if (task.DateCreated < task.NextAction)
            {
                throw new InvalidTaskTimeRangeException(reservation);
            }
            */
            
            Models.Task conflictingTask = await _taskConflictValidator.GetConflictingTask(task);
            if(conflictingTask != null)
            {
                throw new TaskConflictException(conflictingTask, task);
            }    
            
            await _taskCreator.CreateTask(task);
        }
    }
}
