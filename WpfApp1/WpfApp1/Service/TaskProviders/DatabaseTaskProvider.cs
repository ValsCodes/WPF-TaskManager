using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DbContexts;
using WpfApp1.DTOs;
using WpfApp1.Models;

namespace WpfApp1.Service.TaskProviders
{
    public class DatabaseTaskProvider : ITaskProvider
    {
        private readonly TaskDbContextFactory _dbContextFactory;

        public DatabaseTaskProvider(TaskDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            using(TaskmanagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<TaskDTO> taskDTOs = await context.Tasks.ToListAsync();

               return taskDTOs.Select(r => ToTask(r));
            }
        }

        private static Models.Task ToTask(TaskDTO r)
        {
            return new Models.Task(r.TaskName, r.Description, r.Status, r.Type, r.Assigned, r.NextAction);
        }
    }
}
