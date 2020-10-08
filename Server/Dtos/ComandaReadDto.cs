using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Dtos
{
    public class ComandaReadDto
    {
        [Required]
        public int IdC { get; set; }
        [Required]
        public int Id {get; set;}
        public bool Done {get;set;}

        
       
    }
}