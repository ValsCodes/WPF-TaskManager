using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp1.Models
{
    class Task
    {
        [Key]
        public string TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime DateCreated => DateTime.Now;
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string UserID { get; set; }
        public DateTime NextAtion { get; set; }
        public List<Comments> Comments;


        public Task(string taskid, string name, string desc, string status, string type, string userid, DateTime next)
        {
            this.TaskID = taskid;
            this.TaskName = name;
            this.Description = desc;
            this.Status = status;
            this.Type = type;
            this.UserID = userid;
            this.NextAtion = next;
        }

        public Task(string taskid, string name, string desc, string status, string type, string userid, DateTime next, Comments comment)
        {
            this.TaskID = taskid;
            this.TaskName = name;
            this.Description = desc;
            this.Status = status;
            this.Type = type;
            this.UserID = userid;
            this.NextAtion = next;            
            Comments.Add(comment);
        }
    }
}
