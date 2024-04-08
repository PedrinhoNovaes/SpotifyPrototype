using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Streaming.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "BandId is required")]
        public Guid BandId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public List<MusicDto> Songs { get; set; } = new List<MusicDto>();
    }

    public class MusicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
    }

}
