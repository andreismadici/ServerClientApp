using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Dtos
{
    public class ComandaCreateDto
    {
        [Required]
        public int  Id { get; set; }
       
    }
}