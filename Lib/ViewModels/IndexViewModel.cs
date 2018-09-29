using Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
    }
}
