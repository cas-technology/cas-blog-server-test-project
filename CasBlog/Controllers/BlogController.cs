using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasBlog.Models;
using CasBlog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: BlogController
        public ActionResult Index()
        {
            var blogViewModel = new Blog()
            {
                Articles = new List<Article>()
            };
            return View(blogViewModel);
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        private Blog DemoBlogData()
        {
            var authors = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    Email = "author@email.nl",
                    Password = "DSa@#4kdFkdkIC#KL",
                    Description = "A very passionate author about all sorts of topics!",
                    ProfilePictureUrl = "https://www.w3schools.com/html/img_girl.jpg"
                }
            };
            var readers = new List<Reader>();
            var articles = new List<Article>();

            var blogViewModel = new Blog()
            {
                Authors = authors,
                Readers = readers,
                Articles = articles,
            };
            return blogViewModel;
        }
    }
}
