using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Conta.DTO
{
    public struct UsuarioDto
    {
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Senha { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Telefone { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public Guid PlanoId { get; set; }
        [Required]
        public CartaoDto Cartao { get; set; }
    }
}
