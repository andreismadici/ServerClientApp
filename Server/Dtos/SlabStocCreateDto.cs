using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Dtos
{
    public class SlabStocCreateDto
    {
       
        [Required]
        public double  Lungime { get; set; }
        [Required]
        public double Latime {get; set;}
        [Required]
        public string Material {get; set;}
       
        
       
    }
}