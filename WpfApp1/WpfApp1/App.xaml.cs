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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly TaskManager _taskManager;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _taskManager = new TaskManager();
            _navigationStore = new NavigationStore();
        }
 
        protected override void OnStartup(StartupEventArgs e)
        {
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
            return new TaskListingViewModel(_taskManager, new NavigationService(_navigationStore, CreateMakeLIstingViewModel));
        }
    }
}
