using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Dtos
{
    public class ClientLoginDto
    {
        [Required]
        public string Password {get; set;}
        [Required]
        public string Email {get; set;}
    }
}