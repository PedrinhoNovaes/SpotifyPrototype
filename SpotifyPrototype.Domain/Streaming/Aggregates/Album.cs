﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Song> Songs { get; set; } = new List<Song>();
        public void AddSong(Song song) =>
            this.Songs.Add(song);
    }
}