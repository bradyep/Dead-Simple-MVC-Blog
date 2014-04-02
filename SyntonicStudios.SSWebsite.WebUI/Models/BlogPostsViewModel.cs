using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.WebUI.Models
{
    public class BlogPostsViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
