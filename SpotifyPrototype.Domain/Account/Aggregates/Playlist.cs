﻿using SpotifyPrototype.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Account.Aggregates
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Public { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Song> Songs { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
