using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Models
{
    public class Comanda
    {
        [Key]
        public int IdC { get; set; }
        [Required]
        public int Id {get; set;}
        [Required]
        public bool Done{get; set;}

    }
}