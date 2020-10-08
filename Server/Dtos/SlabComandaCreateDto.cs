using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Dtos
{
    public class SlabComandaCreateDto
    {
        
        [Required]
        public double  Lungime { get; set; }
        [Required]
        public double Latime {get; set;}
        [Required]
        public string Material {get; set;}
        [Required]
        public int IdC { get; set; }

        
       
    }
}