using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;
using WpfApp1.Stores;

namespace WpfApp1.ViewModels
{
     class MainViewModel : ViewModelBase
    {      
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
