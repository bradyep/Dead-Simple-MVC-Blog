using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyntonicStudios.SSWebsite.Domain.Entities;

namespace SyntonicStudios.SSWebsite.Domain.Abstract
{
    public interface IExperimentRepository
    {
        IQueryable<Experiment> Experiments { get; }
        void SaveExperiment(Experiment experiment);
        Experiment DeleteExperiment(int experimentID);
    }
}
