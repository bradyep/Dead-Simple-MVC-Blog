using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntonicStudios.SSWebsite.Domain.Entities;
using System.Data.Entity;

namespace SyntonicStudios.SSWebsite.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
    }
}
