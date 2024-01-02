using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Giris.Models
{
    public class Book : BaseModel
    {
        public int PageCount { get; set; }
        public string ISBN { get; set; }
        public int? ShelfId { get; set; }
        public virtual Shelf? Shelf { get; set; }
        public virtual ICollection<Publisher> Publisher { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
