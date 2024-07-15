using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Application.Admin.Dto
{
    public class UsuarioAdminDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório.")]
        [EmailAddress]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório.")]
        public String Senha { get; set; }

        [Required(ErrorMessage = "Campo perfil é obrigatório.")]
        public int? Perfil { get; set; }
    }
}
