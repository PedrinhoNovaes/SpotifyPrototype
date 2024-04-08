using System.ComponentModel.DataAnnotations;

namespace SpotifyPrototype.Api.Controllers.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        public string Password { get; set; }
    }
      
}