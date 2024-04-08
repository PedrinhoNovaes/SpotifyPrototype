using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Repository
{
    public class PlanRepository : RepositoryBase<Plan>
    {
        public SpotifyPrototypeContext Context { get; set; }

        public PlanRepository(SpotifyPrototypeContext context) : base(context)
        {
            Context = context;
        }


    }
}
