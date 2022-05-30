using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    class TaskListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TaskViewModel> _tasks;
        public IEnumerable<TaskViewModel> Tasks => _tasks;
        public ICommand NewTask { get; }

        public TaskListingViewModel()
        {
            _tasks = new ObservableCollection<TaskViewModel>();

            _tasks.Add(new TaskViewModel(new Models.Task("Wash feet","they smell","In Process","Smelling","Ivan", new DateTime(2022,10,12))));
            _tasks.Add(new TaskViewModel(new Models.Task("Wash feet", "they are clean", "Done", "Clean", "Pesho", new DateTime(2015, 5, 6))));
        }
    }
}
