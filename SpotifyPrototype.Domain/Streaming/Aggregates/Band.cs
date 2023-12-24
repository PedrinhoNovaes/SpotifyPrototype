using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyPrototype.Domain.Shared;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Band : Entity
    {
        public string Name { get; set; }
        public Genres Genre { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }

        public Band()
        {
            Albums = new List<Album>();
        }

        public Band(string name, Genres genre, string avatar, string description) : base()
        {
            Name = name;
            Genre = genre;
            Avatar = avatar;
            Description = description;
            Albums = new List<Album>();
        }
    }
}
