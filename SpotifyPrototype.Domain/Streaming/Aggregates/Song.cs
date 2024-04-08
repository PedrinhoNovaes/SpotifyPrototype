using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyPrototype.Domain.Account.Aggregates;
using SpotifyPrototype.Domain.Streaming.ValueObjects;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Duration Duration { get; set; }

        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();
    }

}