using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SyntonicStudios.SSWebsite.Domain.Facades;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace TestWebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BlogPost assembledBlogPost = new BlogPost();
            assembledBlogPost.Subject = TextBox1.Text;

            // Call facade
            BlogPostFacade facade = new BlogPostFacade();
            IBlogPost returnedBlogPost = facade.GetBlogPostIDFromSubjectText(assembledBlogPost);

            Literal1.Text = returnedBlogPost.BlogPostID.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BlogPostService.BlogPostService webService = new BlogPostService.BlogPostService();

            BlogPostService.BlogPost assembledBlogPost = new BlogPostService.BlogPost();
            // BlogPost assembledBlogPost;
            assembledBlogPost.Subject = TextBox2.Text;

            BlogPostService.BlogPost returnedBlogPost = webService.GetBlogPostIDFromSubjectText(assembledBlogPost);
            // IBlogPost returnedBlogPost;
            returnedBlogPost = webService.GetBlogPostIDFromSubjectText(assembledBlogPost);
            Literal2.Text = returnedBlogPost.BlogPostID.ToString();
        }
    }
}
