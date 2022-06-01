using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Stores;
using WpfApp1.Service;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class TaskListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TaskViewModel> _tasks;

        public IEnumerable<TaskViewModel> Tasks => _tasks;

        public ICommand LoadTasksCommand { get; }
        public ICommand NewTask { get; }

        public TaskListingViewModel(TaskManagerStore taskManager, NavigationService makeTaskNavigationService)
        {
            _tasks = new ObservableCollection<TaskViewModel>();

            LoadTasksCommand = new LoadTaskCommand(this, taskManager);
            NewTask = new NavigateCommand(makeTaskNavigationService);           
        }

        public static TaskListingViewModel LoadViewModel(TaskManagerStore taskManager, NavigationService makeTaskNavigationService)
        {
            TaskListingViewModel viewModel = new TaskListingViewModel(taskManager, makeTaskNavigationService);
            viewModel.LoadTasksCommand.Execute(null);
            return viewModel;
        }

        public void UpdateTasks(IEnumerable<Task> tasks)
        {
            _tasks.Clear();

            foreach(Task task in tasks)
            {
                TaskViewModel taskViewModel = new TaskViewModel(task);
                _tasks.Add(taskViewModel);
            }
        }
    }
}
