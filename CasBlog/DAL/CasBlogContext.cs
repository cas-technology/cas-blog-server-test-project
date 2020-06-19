using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CasBlog.Models;

namespace CasBlog.DAL
{
    public class CasBlogContext : DbContext
    {
        public CasBlogContext (DbContextOptions<CasBlogContext> options)
            : base(options)
        {
        }

        public DbSet<CasBlog.Models.Article> Article { get; set; }

        public DbSet<CasBlog.Models.User> User { get; set; }
    }
}
