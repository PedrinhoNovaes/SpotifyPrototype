﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Band
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Backdrop { get; set; }
        public virtual IList<Album> Albums { get; set; } = new List<Album>();

        public void AddAlbum(Album album) =>
            this.Albums.Add(album);
    }

}
