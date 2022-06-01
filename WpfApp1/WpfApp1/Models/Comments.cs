using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfApp1.Models
{
    public class Comments
    {
        [Key]
        public string CommentID { get; set; }
        [Required]
        public int TaskID { get; set; }
        public string UserID { get; set; }
        public DateTime DateAdded => DateTime.Now;
        public string Comment { get; set; }
        public string Type { get; set; }
        public DateTime Reminder => DateTime.Now;
    }
}
