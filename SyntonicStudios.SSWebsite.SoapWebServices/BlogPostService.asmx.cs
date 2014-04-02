using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using SyntonicStudios.SSWebsite.Domain.Entities;
using SyntonicStudios.SSWebsite.Domain.Facades;

namespace SyntonicStudios.SSWebsite.SoapWebServices
{
    /// <summary>
    /// Summary description for BlogPostService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BlogPostService : System.Web.Services.WebService
    {

        [WebMethod]
        public BlogPost GetBlogPostIDFromSubjectText(BlogPost blogPostWithSubject)
        {
            BlogPostFacade facade = new BlogPostFacade();

            BlogPost blogPostWithID = facade.GetBlogPostIDFromSubjectText(blogPostWithSubject);

            return blogPostWithID;
        }
    }
}
