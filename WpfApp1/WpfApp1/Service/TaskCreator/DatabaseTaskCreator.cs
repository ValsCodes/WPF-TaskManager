using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DbContexts;
using WpfApp1.DTOs;

namespace WpfApp1.Service.TaskCreator
{
    class DatabaseTaskCreator : ITaskCreator
    {

        private readonly TaskDbContextFactory _dbContextFactory;

        public DatabaseTaskCreator(TaskDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateTask(Models.Task task)
        {
            using (TaskmanagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                TaskDTO taskDTO = ToTaskDTO(task);
                context.Tasks.Add(taskDTO);
                await context.SaveChangesAsync();
            }
        }

        private TaskDTO ToTaskDTO(Models.Task task)
        {
            return new TaskDTO()
            {
                TaskName = task.TaskName,
                Description = task.Description,
                Status = task.Status,
                Type = task.Type,
                Assigned = task.Assigned,
                NextAction = task.NextAction,
                Comments = task.Comments
            };
        }
    }
}
