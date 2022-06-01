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
    class TaskListingViewModel : ViewModelBase
    {
        private readonly TaskManager _taskManager;
        private readonly ObservableCollection<TaskViewModel> _tasks;

        public IEnumerable<TaskViewModel> Tasks => _tasks;
        public ICommand NewTask { get; }

        public TaskListingViewModel(TaskManager taskManager, NavigationService makeTaskNavigationService)
        {
            _taskManager = taskManager;
            _tasks = new ObservableCollection<TaskViewModel>();

            NewTask = new NavigateCommand(makeTaskNavigationService);

            UpdateTasks();
        }

        private void UpdateTasks()
        {
            _tasks.Clear();

            foreach(Task task in _taskManager.GetAllTasks())
            {
                TaskViewModel taskViewModel = new TaskViewModel(task);
                _tasks.Add(taskViewModel);
            }
        }
    }
}
