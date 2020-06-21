using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasBlog.DAL;
using CasBlog.Models;
using CasBlog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly CasBlogContext _context;
        public BlogController(CasBlogContext context)
        {
            _context = context;
        }
        // GET: BlogController
        public ActionResult Index()
        {
            return View(DemoBlogData());
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
                    ProfilePictureUrl = "https://www.w3schools.com/html/img_girl.jpg",
                    Name = "Author Authorius"
                }
            };
            var readers = new List<Reader>();
            var articles = new List<Article>()
            {
                new Article()
                {
                    Id = 1,
                    Title = "First Blog Article, wow!",
                    Content = "Lorem Ipsum is a great piece of default text used by many developers worldwide",
                    Author = authors[0]
                },
                new Article()
                {
                    Id = 2,
                    Title = "Second Blog Article, wow!",
                    Content = "Lorem Ipsum used to be default text used by many developers worldwide, but not anymore!"
                },
                new Article()
                {
                    Id = 1,
                    Title = "Third Blog Article, SAD!",
                    Content = "Jina Jina Jina"
                }
            };

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
