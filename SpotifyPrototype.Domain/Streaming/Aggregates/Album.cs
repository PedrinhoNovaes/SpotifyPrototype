using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyPrototype.Domain.Shared;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Album : Entity
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public List<Music> Songs { get; set; }

        public Album()
        {
            Songs = new List<Music>();
        }

        public Album(string name, string avatar, string description) : base()
        {
            Name = name;
            Avatar = avatar;
            Description = description;
            Songs = new List<Music>();
        }
    }
}