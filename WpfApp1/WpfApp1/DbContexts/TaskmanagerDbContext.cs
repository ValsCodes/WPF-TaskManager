using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTOs;
using WpfApp1.Models;

namespace WpfApp1.DbContexts
{
    public class TaskmanagerDbContext : DbContext
    {
        public TaskmanagerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TaskDTO> Tasks { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
