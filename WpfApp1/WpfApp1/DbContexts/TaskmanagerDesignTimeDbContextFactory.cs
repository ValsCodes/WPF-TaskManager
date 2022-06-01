using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DbContexts
{
    public class TaskmanagerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskmanagerDbContext>
    {
        public TaskmanagerDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer
                ("Server=DESKTOP-37O5L0E\\MSSQLSERVER01;Database=TaskManager;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            return new TaskmanagerDbContext(options);
        }
    }
}
