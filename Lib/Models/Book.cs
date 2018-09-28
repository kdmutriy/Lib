using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public ICollection<Author> Authors { get; set; }
        public Book()
        {
            Authors = new List<Author>();
        }
    }
}
