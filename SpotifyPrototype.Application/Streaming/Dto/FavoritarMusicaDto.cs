using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Streaming.Dto
{
    public class FavoritarMusicaDto
    {
        [Required]
        public Guid MusicaId { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
    }
}
