using CasBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasBlog.ViewModels
{
    public class Blog
    {
        public List<Author> Authors { get; set; }
        public List<Reader> Readers { get; set; }
        public List<Article> Articles { get; set; }
    }
}
