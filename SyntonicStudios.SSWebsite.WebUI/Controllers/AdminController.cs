using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntonicStudios.SSWebsite.Domain.Abstract;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IBlogPostRepository repository;

        public AdminController(IBlogPostRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.BlogPosts);
        }

        public ViewResult Edit(int blogPostID)
        {
            BlogPost blogPost = repository.BlogPosts.FirstOrDefault(p => p.BlogPostID == blogPostID);
            return View(blogPost);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(BlogPost blogPost)
        {
            // if (ModelState.IsValid && blogPost.BlogPostID != 0)
            if (ModelState.IsValid)
            {
                repository.SaveBlogPost(blogPost);
                TempData["message"] = string.Format("{0} has been saved", blogPost.Subject);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(blogPost);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new BlogPost { DatePosted = DateTime.Now });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int blogPostId)
        {
            BlogPost deletedBlogPost = repository.DeleteBlogPost(blogPostId);
            if (deletedBlogPost != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedBlogPost.Subject);
            }
            return RedirectToAction("Index");
        }

    }
}
