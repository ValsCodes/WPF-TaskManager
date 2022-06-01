using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp1.Models
{
    public class Task
    {
       // protected static int autoicrementid = 1;
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime DateCreated => DateTime.Now;
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Assigned { get; set; }
        public DateTime NextAction { get; set; } = DateTime.Now;
        public ICollection<Comments> Comments { get; set; }

        /*
        public Task(string name, string desc, string status, string type, string userid, DateTime next)
        {
         //   this.TaskID =  autoicrementid++.ToString();
            this.TaskName = name;
            this.Description = desc;
            this.Status = status;
            this.Type = type;
            this.Assigned = userid;
            this.NextAction = next;
        }

        public Task(string name, string desc, string status, string type, string userid, DateTime next, Comments comment)
        {
          //  this.TaskID = taskid;
            this.TaskName = name;
            this.Description = desc;
            this.Status = status;
            this.Type = type;
            this.Assigned = userid;
            this.NextAction = next;            
            Comments.Add(comment);
        }

        */

        public bool Conflicts(Task task) //doesn't work, allows for identical tasks
        {
           if(task.TaskName == TaskName)
            {
                return false;
            }
            return  task.DateCreated < NextAction || task.NextAction > DateCreated;
        }
    }
}
