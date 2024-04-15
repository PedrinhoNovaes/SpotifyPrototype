using SpotifyPrototype.Application.Conta.DTO;
using SpotifyPrototype.Domain.Streaming.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Streaming.Dto
{
    public class PlayListDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public TipoPlayList TipoPlayList { get; set; }
        public UsuarioDto Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Publica { get; set; }
        public List<MusicaDto> Musicas { get; set; }
    }
}
