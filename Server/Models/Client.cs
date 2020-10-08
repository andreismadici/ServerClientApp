using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Password {get; set;}
        [Required]
        public string Email {get; set;}
    }
}