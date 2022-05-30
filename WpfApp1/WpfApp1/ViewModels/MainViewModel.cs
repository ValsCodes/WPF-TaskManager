using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
     class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
         
        public MainViewModel(TaskManager manager)
        {
            CurrentViewModel = new MakeTaskViewModel(manager);
        }
        
        /*
        public MainViewModel()
        {
            CurrentViewModel = new TaskListingViewModel();
        }
        */
    }
}
