using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntonicStudios.SSWebsite.Domain.Abstract;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.Domain.Concrete
{
    public class EFBlogPostRepository : IBlogPostRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<BlogPost> BlogPosts
        {
            get { return context.BlogPosts; }
        }

        public void SaveBlogPost(BlogPost blogPost)
        {
            if (blogPost.BlogPostID == 0)
            {
                context.BlogPosts.Add(blogPost);
            }
            else
            {
                BlogPost dbEntry = context.BlogPosts.Find(blogPost.BlogPostID);
                if (dbEntry != null)
                {
                    dbEntry.CategoryID = blogPost.CategoryID;
                    dbEntry.Subject = blogPost.Subject;
                    dbEntry.Body = blogPost.Body;
                    dbEntry.Teaser = blogPost.Teaser;
                    dbEntry.DatePosted = blogPost.DatePosted;
                    dbEntry.PostedBy = blogPost.PostedBy;
                    dbEntry.UrlDisplay = blogPost.UrlDisplay;
                }
            }
            context.SaveChanges();
        }

        public BlogPost DeleteBlogPost(int blogPostID)
        {
            BlogPost dbEntry = context.BlogPosts.Find(blogPostID);
            if (dbEntry != null)
            {
                context.BlogPosts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
