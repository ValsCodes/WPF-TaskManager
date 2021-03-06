using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Stores;
using WpfApp1.Service;

namespace WpfApp1.ViewModels
{
    class MakeTaskViewModel : ViewModelBase
    {
        private string _taskname;
        public string TaskName
        {
            get { return _taskname; }
            set { _taskname = value; OnPropertyChanged(nameof(TaskName));}
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        private string _assigned;
        public string Assigned
        {
            get { return _assigned; }
            set { _assigned = value; OnPropertyChanged(nameof(Assigned)); }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged(nameof(Type)); }
        }

        private DateTime _nextAction = DateTime.Now;
        public DateTime NextAction
        {
            get { return _nextAction; }
            set { _nextAction = value; OnPropertyChanged(nameof(NextAction)); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; OnPropertyChanged(nameof(Comment)); }
        }
     
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeTaskViewModel(TaskManager manager, NavigationService taskViewNavigationService)
        {
            SubmitCommand = new MakeTaskCommand(this, manager, taskViewNavigationService);
            CancelCommand = new NavigateCommand(taskViewNavigationService);
        }

    }
}
