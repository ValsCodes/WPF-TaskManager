using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DbContexts
{
    public class TaskmanagerDbContext : DbContext
    {
        public TaskmanagerDbContext(DbContextOptions<TaskmanagerDbContext> options) : base(options)
        {

        }

        public DbSet<WpfApp1.Models.Task> Tasks { get; set; }
        public DbSet<WpfApp1.Models.Comments> Comments { get; set; }
    }
}
