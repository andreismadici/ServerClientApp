using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Dtos
{
    public class ClientCreateDto
    {
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Password {get; set;}
        [Required]
        public string Email {get; set;}
    }
}