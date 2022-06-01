using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DbContexts
{
    public class TaskDbContextFactory
    {
        private readonly string _connectionString;

        public TaskDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TaskmanagerDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;
            return new TaskmanagerDbContext(options);
        }
    }
}
