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
        [Required]
        public String Nome { get; set; }
        public String Capa { get; set; }
        public Guid IdAutorPrincipal { get; set; }

        [Required]
        public List<MusicaDto> Musicas { get; set; } = [];
    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Duracao { get; set; }
        [Required]
        public String Letra { get; set; }
        [Required]
        public Guid IdEstiloMusical { get; set; }

        public Boolean favorito { get; set; }

        public String NomeEstiloMusical { get; set; }

        public String Autores { get; set; }
    }
}
