using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfApp1.Exceptions;
using WpfApp1.Models;
using WpfApp1.Service;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands
{
    class MakeTaskCommand : AsyncCommandBase
    {
        private readonly MakeTaskViewModel _makeTaskViewModel;
        private readonly TaskManager _taskManager;
        private readonly NavigationService _taskViewNavigationService;

        public MakeTaskCommand(MakeTaskViewModel makeTaskViewModel, TaskManager manager, NavigationService taskViewNavigationService)
        {
            _taskManager = manager;
            _makeTaskViewModel = makeTaskViewModel;
            _taskViewNavigationService = taskViewNavigationService;

        }
        public override async System.Threading.Tasks.Task ExecuteAsync(object parameter)
        {
          //  _makeTaskViewModel.SubmitErrorMessage = string.Empty;
           // _makeTaskViewModel.IsSubmitting = true;

            Task task = new Task(
                _makeTaskViewModel.TaskName, 
                _makeTaskViewModel.Description,
                _makeTaskViewModel.Status,
                _makeTaskViewModel.Type,
                _makeTaskViewModel.Assigned,
                _makeTaskViewModel.NextAction
                );
            try
            {
                await _taskManager.AddTask(task);
                MessageBox.Show("Successfully added task", "Success",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                _taskViewNavigationService.Navigate();
            }
            catch (TaskConflictException)
            {

                MessageBox.Show("This task already exists","Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Faild to make task", "Error",
                     MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
