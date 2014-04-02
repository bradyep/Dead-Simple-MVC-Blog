using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.Domain.Abstract
{
    public interface IBlogPostRepository
    {
        IQueryable<BlogPost> BlogPosts { get; }
        void SaveBlogPost(BlogPost blogPost);
        BlogPost DeleteBlogPost(int blogPostID);
    }
}
