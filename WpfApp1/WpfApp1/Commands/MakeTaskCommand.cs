using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfApp1.Exceptions;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands
{
    class MakeTaskCommand : CommandBase
    {
        private readonly MakeTaskViewModel _makeTaskViewModel;
        private readonly TaskManager _taskManager;


        public MakeTaskCommand(MakeTaskViewModel makeTaskViewModel, TaskManager manager)
        {
            _taskManager = manager;
            _makeTaskViewModel = makeTaskViewModel;
        }
        public override void Execute(object parameter)
        {
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
                _taskManager.AddTask(task);
                MessageBox.Show("Successfully added task", "Success",
                     MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (TaskConflictException)
            {

                MessageBox.Show("This task already exists","Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
