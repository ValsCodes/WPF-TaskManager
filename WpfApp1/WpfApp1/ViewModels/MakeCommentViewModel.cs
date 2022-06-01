using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MakeCommentViewModel
    {
        private readonly Comments _comment;
        public int TaskID => _comment.TaskID;
        public string UserID => _comment.UserID;
        public DateTime DateAdded => DateTime.Now;
        public string Comment => _comment.Comment;
        public string Type => _comment.Type;
        public DateTime Reminder => DateTime.Now;

        public MakeCommentViewModel(Comments comment)
        {
            _comment = comment;
        }
    }
}
