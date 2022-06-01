using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Stores;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands
{
    public class LoadTaskCommand : AsyncCommandBase
    {
        private readonly TaskListingViewModel _viewModel;
        private readonly TaskManagerStore _taskManagerStore;

        public LoadTaskCommand(TaskListingViewModel viewModel, TaskManagerStore taskManagerStore)
        {
            _viewModel = viewModel;
            _taskManagerStore = taskManagerStore;
        }

        public override async System.Threading.Tasks.Task ExecuteAsync(object parameter)
        {
            try
            {
                _viewModel.UpdateTasks(_taskManagerStore.Tasks);
            }
            catch (Exception)
            {

                MessageBox.Show("Successfully loaded tasks", "Information",
                     MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
