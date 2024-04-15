using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Repository
{
    public class AlbumRepository : RepositoryBase<Album>
    {
        public AlbumRepository(SpotifyPrototypeContext context) : base(context) { }
    }
}
