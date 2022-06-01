using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DbContexts;
using WpfApp1.DTOs;

namespace WpfApp1.Service.TaskConflictValidators
{
    public class DatabaseTaskConflictValidator : ITaskConflictValidator
    {
        private readonly TaskDbContextFactory _dbContextFactory;

        public DatabaseTaskConflictValidator(TaskDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Models.Task> GetConflictingTask(Models.Task task)
        {
            using (TaskmanagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                TaskDTO taskDTO = await context.Tasks
                    .Where(x => x.TaskName == task.TaskName)
                    .Where(x => x.Description == task.Description)
                    .Where(x => x.Status == task.Status)
                    .Where(x => x.Type == task.Type)
                    .Where(x => x.Assigned == task.Assigned)
                    .Where(x => x.NextAction == task.NextAction).FirstOrDefaultAsync();

                if(taskDTO == null)
                {
                    return null;
                }

                return ToTask(taskDTO);
            }
        }

        private static Models.Task ToTask(TaskDTO r)
        {
            return new Models.Task(r.TaskName, r.Description, r.Status, r.Type, r.Assigned, r.NextAction);
        }
    }
}
