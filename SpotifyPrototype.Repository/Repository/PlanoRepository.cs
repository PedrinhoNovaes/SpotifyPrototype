using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public PlanoRepository(SpotifyPrototypeContext context) : base(context) { }
    }
}
