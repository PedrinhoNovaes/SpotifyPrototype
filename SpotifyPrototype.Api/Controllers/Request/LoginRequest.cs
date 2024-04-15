using System.ComponentModel.DataAnnotations;

namespace SpotifyPrototype.Api.Controllers.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "É obrigatório infromar o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório infromar a senha.")]
        public string Senha { get; set; }
    }

}