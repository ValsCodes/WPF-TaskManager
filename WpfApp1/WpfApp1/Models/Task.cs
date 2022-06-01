using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp1.Models
{
    public class Task
    {

        public string TaskName { get; set; }
        public DateTime DateCreated => DateTime.Now;
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Assigned { get; set; }
        public DateTime NextAction { get; set; } = DateTime.Now;
        public ICollection<Comments> Comments { get; set; }

        
        public Task(string name, string desc, string status, string type, string userid, DateTime next)
        {
            this.TaskName = name;
            this.Description = desc;
            this.Status = status;
            this.Type = type;
            this.Assigned = userid;
            this.NextAction = next;
        }
        
        public Task(string name, string desc, string status, string type, string userid, DateTime next, Comments comment)
        {
            this.TaskName = name;
            this.Description = desc;
            this.Status = status;
            this.Type = type;
            this.Assigned = userid;
            this.NextAction = next;            
            Comments.Add(comment);
        }
       
    }
}
