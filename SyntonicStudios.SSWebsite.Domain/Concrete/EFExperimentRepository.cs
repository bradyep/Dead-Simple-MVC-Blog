using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntonicStudios.SSWebsite.Domain.Abstract;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.Domain.Concrete
{
    public class EFExperimentRepository : IExperimentRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Experiment> Experiments
        {
            get { return context.Experiments; }
        }

        public void SaveExperiment(Experiment experiment)
        {
            if (experiment.ExperimentId == 0)
            {
                context.Experiments.Add(experiment);
            }
            else
            {
                Experiment dbEntry = context.Experiments.Find(experiment.ExperimentId);
                if (dbEntry != null)
                {
                    // Update all data fields
                    dbEntry.ExperimentId = experiment.ExperimentId;
                    dbEntry.DisplayName = experiment.DisplayName;
                    dbEntry.Body = experiment.Body;
                    dbEntry.UseTemplate = experiment.UseTemplate;
                    dbEntry.CreatedOn = experiment.CreatedOn;
                    dbEntry.LastModified = experiment.LastModified;
                    dbEntry.UrlDisplay = experiment.UrlDisplay;
                }
            }
            context.SaveChanges();
        }

        public Experiment DeleteExperiment(int experimentID)
        {
            Experiment dbEntry = context.Experiments.Find(experimentID);
            if (dbEntry != null)
            {
                context.Experiments.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    } // End of class
}
