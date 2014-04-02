using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntonicStudios.SSWebsite.Domain.Abstract;
using SyntonicStudios.SSWebsite.Domain.Entities;
using SyntonicStudios.SSWebsite.WebUI.Models;

namespace SyntonicStudios.SSWebsite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private IBlogPostRepository repository;
        private IExperimentRepository expRepository;
        public int PageSize = 4;

        // public HomeController()
        public HomeController(IBlogPostRepository blogPostRepository, IExperimentRepository experimentRepository)
        {
            this.repository = blogPostRepository;
            this.expRepository = experimentRepository;
        }

        public ActionResult Index(int page = 1)
        {
            BlogPostsViewModel model = new BlogPostsViewModel
            {
                BlogPosts = repository.BlogPosts.OrderByDescending(b => b.DatePosted).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.BlogPosts.Count()
                }
            };
            ViewBag.Message = "Syntonic Studios Blog";

            // return View();
            // return View(repository.BlogPosts);
            return View(model);
        }

        public ActionResult Experiments()
        {
            ExperimentNavItemModel model = new ExperimentNavItemModel
            {
                // In the future we may want to divide these up by pages
                Experiments = expRepository.Experiments.OrderByDescending(e => e.CreatedOn)
            };

            return View(model);
        }

        public ViewResult ViewBlog(string id)
        {
            // BlogPost blogPost = repository.BlogPosts.FirstOrDefault(p => p.UrlDisplay == blogPostUrlDisplay);
            BlogPost blogPost = repository.BlogPosts.FirstOrDefault(p => p.UrlDisplay == id);
            if (blogPost != null)
            {
                return View(blogPost);
            }
            else
                throw new Exception("No blog post found with that UrlDisplay");
        }

        public ViewResult ViewExperiment(string id)
        {
            Experiment experiment = expRepository.Experiments.FirstOrDefault(x => x.UrlDisplay == id);
            if (experiment != null)
            {
                return View(experiment);
            }
            else
                throw new Exception("No experiment found with that UrlDisplay");
        }

        public ActionResult AboutThisWebsite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            return View();
        }

        public string Count()
        {
            int count = repository.BlogPosts.Count();
            return count.ToString();
        }

    }
}
