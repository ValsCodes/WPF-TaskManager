using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Stores;
using WpfApp1.ViewModels;
using WpfApp1.Service;
using Microsoft.EntityFrameworkCore;
using WpfApp1.DbContexts;
using WpfApp1.Service.TaskProviders;
using WpfApp1.Service.TaskConflictValidators;
using WpfApp1.Service.TaskCreator;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Server=DESKTOP-37O5L0E\\MSSQLSERVER01;Database=TaskManager;Trusted_Connection=True;MultipleActiveResultSets=true";

        private readonly NavigationStore _navigationStore;
        private readonly TaskManager _taskManager;
        private readonly TaskManagerStore _taskManagerStore;
        private readonly TaskDbContextFactory _taskDbContextFactory;


        public App()
        {
            _taskDbContextFactory = new TaskDbContextFactory(ConnectionString);
             ITaskProvider taskProvider = new DatabaseTaskProvider(_taskDbContextFactory);
              ITaskCreator taskCreator = new DatabaseTaskCreator(_taskDbContextFactory);
              ITaskConflictValidator taskConflictValidator = new DatabaseTaskConflictValidator(_taskDbContextFactory);

            _taskManager = new TaskManager(taskProvider, taskCreator, taskConflictValidator);
            _taskManagerStore = new TaskManagerStore(_taskManager);
            _navigationStore = new NavigationStore();
        }
 
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options;
            using (TaskmanagerDbContext dbContext = _taskDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }
            
            _navigationStore.CurrentViewModel = CreateTaskViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private MakeTaskViewModel CreateMakeLIstingViewModel()
        {
            return new MakeTaskViewModel(_taskManager, new NavigationService (_navigationStore, CreateTaskViewModel));
        }

        private TaskListingViewModel CreateTaskViewModel()
        {
            return TaskListingViewModel.LoadViewModel(_taskManagerStore, new NavigationService(_navigationStore, CreateMakeLIstingViewModel));
        }
    }
}
