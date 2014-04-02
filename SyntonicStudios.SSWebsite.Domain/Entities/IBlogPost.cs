using System;
namespace SyntonicStudios.SSWebsite.Domain.Entities
{
    public interface IBlogPost
    {
        int BlogPostID { get; set; }
        string Body { get; set; }
        int? CategoryID { get; set; }
        DateTime DatePosted { get; set; }
        int? PostedBy { get; set; }
        string Subject { get; set; }
        string Teaser { get; set; }
        string UrlDisplay { get; set; }
    }
}
