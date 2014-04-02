using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SyntonicStudios.SSWebsite.Domain.Entities;
using SyntonicStudios.SSWebsite.Domain.Concrete;

namespace SyntonicStudios.SSWebsite.Domain.Facades
{
    public class BlogPostFacade
    {
        private EFBlogPostRepository repository = new EFBlogPostRepository();

        /// <summary>
        /// Accepts a BlogPost with a subject, tries to return a BlogPost object with an ID
        /// </summary>
        /// <param name="blogPostWithSubject"></param>
        /// <returns></returns>
        public BlogPost GetBlogPostIDFromSubjectText(BlogPost blogPostWithSubject)
        {
            BlogPost blogPostWithID = new BlogPost();
            blogPostWithID = repository.BlogPosts.FirstOrDefault(p => p.Subject.ToUpper().Contains(blogPostWithSubject.Subject.ToUpper())) ?? new BlogPost{ BlogPostID = 0 };

            return blogPostWithID;
        }
    }
}
