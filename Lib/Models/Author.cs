using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string NameAuthor { get; set; }
        public List<Library> Libraries { get; set; }
        public Author()
        {
            Libraries = new List<Library>();
        }
    }
}
