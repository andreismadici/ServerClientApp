using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Models
{
    public class SlabStoc
    {
        [Key]
        public int IdSS { get; set; }
        [Required]
        public string  Material { get; set; }
        [Required]
        public double Lungime {get; set;}
        [Required]
        public double Latime {get; set;}
        [Required]
        public bool Taken {get; set;}

        public SlabStoc(double lungime, double latime, string material)
        {
            
            this.Lungime = lungime;
            this.Latime = latime; 
            this.Material = material;
            
        }
        public SlabStoc()
        {

        }
        public override string ToString()
        {
            return "ID: " + IdSS + " Lungime: " + Lungime + " Latime: " + Latime;
        }

    }
}