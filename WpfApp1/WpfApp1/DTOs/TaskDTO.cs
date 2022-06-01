using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DTOs
{
    public class TaskDTO 
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Assigned { get; set; }
        public DateTime NextAction { get; set; }
        public ICollection<Comments> Comments { get; set; }

    }
}
