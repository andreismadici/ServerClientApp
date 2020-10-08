using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerMagazin.Models
{
    public class SlabReturned
    {
        
        public List<int> IdSC { get; set; }
        
        public List<int> IdSS { get; set; }
        
        public List<int> IdSN {get; set;}
        
        public SlabReturned ()
        {
            IdSC = new List<int>();
            IdSS = new List<int>();
            IdSN = new List<int>();

        }

        public override string ToString()
        {
            return " " + IdSC.Count + "  " + IdSS.Count + "  " + IdSN.Count;
        }
    }
}