using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDo : BaseModel
    {
        public string? Description { get; set; }
        public DateTime DeadLine { get; set; } = DateTime.Now;
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public int? StatusId { get; set; }
        public virtual Status? status { get; set; }
        public int? PriorityId { get; set; }
        public virtual Priority? priority { get; set; } 
    }
}
