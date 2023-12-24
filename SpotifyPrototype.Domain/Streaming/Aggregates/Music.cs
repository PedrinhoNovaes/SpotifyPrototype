using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyPrototype.Domain.Shared;

namespace SpotifyPrototype.Domain.Streaming.Aggregates
{
    public class Music : Entity
    {
        public string Name { get; set; }
        public int DurationInSeconds { get; set; }
        public string Lyrics { get; set; }

        public int DurationMinutes
        {
            get { return DurationInSeconds / 60; }
            set { DurationInSeconds = value * 60 + (DurationInSeconds % 60); }
        }

        public int DurationSeconds
        {
            get { return DurationInSeconds % 60; }
            set { DurationInSeconds = (DurationInSeconds / 60) * 60 + value; }
        }

        public Music(string name, int durationMinutes, int durationSeconds, string lyrics) : base()
        {
            Name = name;
            DurationMinutes = durationMinutes;
            DurationSeconds = durationSeconds;
            Lyrics = lyrics;
        }
    }
}