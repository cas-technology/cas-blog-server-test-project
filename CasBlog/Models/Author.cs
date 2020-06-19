using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasBlog.Models
{
    public class Author: User
    {
        [Required]
        public string Description { get; set; }

        public string ProfilePictureUrl { get; set; }
    }
}
