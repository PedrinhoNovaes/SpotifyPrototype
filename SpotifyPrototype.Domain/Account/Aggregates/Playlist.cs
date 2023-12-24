using SpotifyPrototype.Domain.Shared;
using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Account.Aggregates

{
    public class Playlist : Entity
    {
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public List<Music> Songs { get; set; }

        public Playlist()
        {
            Songs = new List<Music>();
        }

        public Playlist(string name, bool isPublic, string avatar, string description) : base()
        {
            Name = name;
            IsPublic = isPublic;
            Avatar = avatar;
            Description = description;
            Songs = new List<Music>();
        }
    }
}