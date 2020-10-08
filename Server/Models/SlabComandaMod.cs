using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Models
{
    public class SlabComandaMod
    {
        [Key]
        public int id { get; set; }
        [Required]
        public double  lungime { get; set; }
        [Required]
        public double latime {get; set;}
        [Required]
        public int id1 { get; set; }
        [Required]
        public int id2 { get; set; }
        [Required]
        public int idPlacaStoc { get; set; }
        [Required]
        public string Material {get; set;}
        [Required]
        public int idBun{get; set;}

        public SlabComandaMod(int id, double lungime, double latime, int idBun)
        {
            this.id = id;
            this.lungime = lungime;
            this.latime = latime;
            this.id1 = 0;
            this.id2 = 0;
            this.idPlacaStoc = 0;
            this.idBun = idBun;
        }

        public SlabComandaMod(int id, double lungime, double latime, int id1, int id2)
        {
            this.id = id;
            this.lungime = lungime;
            this.latime = latime;
            this.id1 = id1;
            this.id2 = id2;
            this.idPlacaStoc = 0;
            this.idBun = 0;
        }

        public SlabComandaMod()
        {

        }

        public override string ToString()
        {
            return "ID: " + id + " Lungime: " + lungime + " Latime: " + latime + " Parinti " + id1 + " " + id2 + " " + idPlacaStoc + " " + idBun;
        }

    }
}