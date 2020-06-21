using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasBlog.Models
{
    public class Reader: User
    {
        public List<Article> LikedArticles { get; set; }
    }
}
