using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Dtos
{
    public class SlabStocReadDto
    {
        [Key]
        public int IdSS { get; set; }
        [Required]
        public double  Lungime { get; set; }
        [Required]
        public double Latime {get; set;}
        [Required]
        public string Material {get; set;}
        [Required]
        public bool Taken {get; set;}

        
       
    }
}