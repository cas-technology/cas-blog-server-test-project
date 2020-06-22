using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Author author = DemoBlogData().Articles.Where(article => article.Id == id).First().Author;
            Article article = DemoBlogData().Articles.Where(article => article.Id == id).FirstOrDefault();
            Reader reader = DemoBlogData().Readers.Where(reader => reader.LikedArticles.Contains(article)).FirstOrDefault();

            var blogViewModel = new Blog()
            {
                Authors = new List<Author>()
                {
                    author
                },
                Articles = new List<Article>()
                {
                    article
                },
                Readers = new List<Reader>()
                {
                    reader
                }
            };

            ViewData["Title"] = "Details for " + blogViewModel.Articles.First().Title;

            var articleId = blogViewModel.Articles.First().Id;

            var sessionViewCount = HttpContext.Session.GetInt32("TimesViewed " + articleId);
            if (sessionViewCount >= 0)
            {
                HttpContext.Session.SetInt32("TimesViewed " + articleId, (int)(sessionViewCount + 1));
            } else
            {
                HttpContext.Session.SetInt32("TimesViewed " + articleId, 1);
            }

            int cookieViewCount;
            int.TryParse(HttpContext.Request.Cookies["TimesViewed " + articleId], out cookieViewCount);

            int newCookieVal;
            if (cookieViewCount >= 0)
            {
                newCookieVal = cookieViewCount + 1;
            }
            else
            {
                newCookieVal = 1;
            }
            var option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7)
            };

            Response.Cookies.Append("TimesViewed " + articleId, newCookieVal.ToString(), option);

            return View(blogViewModel);
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
            var readers = new List<Reader>()
            {
                new Reader()
                {
                    Id = 2,
                    Email = "reader@email.nl",
                    Password = "NotSoSecureAfterAll",
                    LikedArticles = new List<Article>()
                    {
                        new Article()
                        {
                            Id = 1,
                            Title = "First Blog Article, wow!",
                            Content = "Lorem Ipsum is a great piece of default text used by many developers worldwide",
                            Author = authors[0]
                        },
                    }
                }
            };
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
                    Content = "Lorem Ipsum used to be default text used by many developers worldwide, but not anymore!",
                    Author = authors[0]
                },
                new Article()
                {
                    Id = 3,
                    Title = "Third Blog Article, SAD!",
                    Content = "Jina Jina Jina",
                    Author = authors[0]
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
