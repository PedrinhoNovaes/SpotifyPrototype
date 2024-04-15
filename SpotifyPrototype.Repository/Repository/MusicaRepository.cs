using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Repository
{
    public class MusicaRepository : RepositoryBase<Musica>
    {
        public MusicaRepository(SpotifyPrototypeContext context) : base(context) { }
    }
}
