using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerMagazin.Data;
using ServerMagazin.Models;

namespace ServerMagazin.ComandaAlgorithm
{
    public class ComAlgorithm
    {

        private readonly CommanderContext _context;
        private readonly ISlabComandaRepository _repositoryComanda;
        private readonly ISlabStocRepository _repositoryStoc;
        

        public ComAlgorithm(CommanderContext context, ISlabComandaRepository sqlComandaRepository, ISlabStocRepository slabStocRepository)
        {
            _context = context;
            _repositoryComanda = sqlComandaRepository;
            _repositoryStoc = slabStocRepository;
            
        }

        public bool Conditie(List<SlabComandaMod> slabs, List<int> parinti, List<SlabComandaMod> cmd)
        {
            int count = 0;
            List<SlabComandaMod> parcurgere = new List<SlabComandaMod>();
            List<int> firstSlab = new List<int>();
            foreach (var x in slabs)
            {
                parcurgere.Add(x);
                int k = 0;
                int cant = parcurgere.Count;
                
                while (k < cant)
                {
                    
                    if (parcurgere[k].id1 != 0)
                    {
                        parcurgere.Add(cmd[parcurgere[k].id1 - 1]);
                        parcurgere.Add(cmd[parcurgere[k].id2 - 1]);
                        cant++;
                        cant++;
                    }
                    else
                    {
                        firstSlab.Add(parcurgere[k].id);
                    }
                    
                    k++;
                }
                parcurgere.Clear();
            }
            

            if (firstSlab.Count == parinti.Count)
            {
                
                foreach (var z in parinti)
                {
                    count = 0;
                    foreach(var z1 in firstSlab)
                    {
                        if (z == z1)
                            count++;
                    }
                    
                    if (count != 1)
                        return false;
                }
                return true;
            }
                    
            return false;
        }


        public bool Compatibili(SlabComandaMod first, SlabComandaMod  second, List<SlabComandaMod > cmd)
        {
            
            int k = 0;
            List<int> firstSlab = new List<int>();
            List<int> secondSlab = new List<int>();
            List<SlabComandaMod > parcurgere = new List<SlabComandaMod >();
            parcurgere.Add(first);
            k = 0;
            int cant = parcurgere.Count;
            while (k < cant)
            {
                if (parcurgere[k].id1 != 0)
                {
                    parcurgere.Add(cmd[parcurgere[k].id1 - 1]);
                    parcurgere.Add(cmd[parcurgere[k].id2 - 1]);
                    cant++;
                    cant++;
                }
                else
                {
                    firstSlab.Add(parcurgere[k].id);
                }
                k++;
            }
            parcurgere.Clear();
            parcurgere.Add(second);
            k = 0;
            cant = parcurgere.Count;
            while (k < cant)
            {
                if (parcurgere[k].id1 != 0)
                {
                    parcurgere.Add(cmd[parcurgere[k].id1 - 1]);
                    parcurgere.Add(cmd[parcurgere[k].id2 - 1]);
                    cant++;
                    cant++;
                }
                else
                {
                    secondSlab.Add(parcurgere[k].id);
                }
                k++;
            }
            bool sePoate = true;
            foreach (var m in firstSlab)
                foreach (var m1 in secondSlab)
                    if (m == m1)
                        sePoate = false;
            if (sePoate == true)
            {
                return true;
            }
            return false;
        }

        public SlabReturned CmdAlgorithm(List<SlabComanda> comandaAdusa, List<SlabStoc> noustoc)
        {
            
           //Initializam lista pentru stoc/ comanda si parinti (ce contine placilele din comanda)
            List<SlabStoc> stoc = new List<SlabStoc>();
            List<SlabComandaMod> cmd = new List<SlabComandaMod>();
            List<int> parinti = new List<int>();

            int indexBun = 1;
            foreach(var ceva in comandaAdusa)
            {
                cmd.Add(new SlabComandaMod(indexBun,ceva.Lungime,ceva.Latime,ceva.IdSC));
                parinti.Add(indexBun);
                indexBun ++;
            }
            foreach(var ceva in noustoc)
                stoc.Add(ceva);
            //Initializa ID-ul pentru prima placa pe care o vom "construi"
            int newId = cmd[cmd.Count-1].id+1;

            int i = 0;
            int j = 1;
            int cantitate = cmd.Count;
            List<SlabComandaMod> parcurgere = new List<SlabComandaMod>();

            bool ok = true;
           
                
            while (i < cantitate)
            {
                    j = i + 1;
                    while(j < cantitate) 
                    {
                        if (cmd[i].lungime == cmd[j].lungime)
                        {
                            if (Compatibili(cmd[i], cmd[j], cmd) == true)
                            {
                                cmd.Add(new SlabComandaMod() { id = newId, lungime = cmd[i].lungime, latime = cmd[i].latime + cmd[j].latime, id1 = cmd[i].id, id2 = cmd[j].id });
                                newId++;
                                cantitate = cantitate + 1;
                            }
                        }
                       
                        if (cmd[i].latime == cmd[j].latime)
                        {
                            if (Compatibili(cmd[i], cmd[j], cmd) == true)
                            { 
                                cmd.Add(new SlabComandaMod() { id = newId, lungime = cmd[i].lungime + cmd[j].lungime, latime = cmd[i].latime, id1 = cmd[i].id, id2 = cmd[j].id });
                                newId++;
                                cantitate = cantitate + 1;
                            }
                        }
                        
                        j = j + 1;
                        
                    }
                    
                    i = i + 1;

           } 

            
            Console.WriteLine("Placile obtinute dupa adunare");
            foreach (var g in cmd)
                Console.WriteLine(g); //Pana aici e bine
            Console.WriteLine(" ");
            
            List<int> ordine = new List<int>();
            List<int> cautare = new List<int>();
             
            List<SlabComandaMod> slabs = new List<SlabComandaMod>();
            cantitate = cmd.Count;
            i = 0;

            int placiTaiate = 0;

            double sumLng = 0;
            double sumLat = 0;
            int PlaciTaiate = 200;
            double lng = 100;
            double lat = 100;
            List<int> PlaciFinale = new List<int>();
            List<int> StocFinal = new List<int>();

            double newLng = 5;
            double newLat = 5;
            double pierderLng = 0;
            double pierderLat = 0;
            
            int idPlacaTaiata = 0;

            int newCant = 0;
            bool ok1 = false;
            int okZero = 0;
            int zero = 200;
            while (i < cantitate)
            {
                
                cautare.Clear();
                cautare.Add(cmd[i].id);
                newCant = cautare.Count;
                j = i + 1;
                
                if (j < cantitate)
                {
                    
                    while (newCant != 0)
                    {

                        if (j < cantitate)
                        {
                            ok = true;
                            ok1 = false;
                            foreach (var z in cautare)
                            {
                                if (Compatibili(cmd[z - 1], cmd[j], cmd) == false)
                                {
                                    ok = false;

                                }
                            }
                            if (ok == true)
                            {
                                cautare.Add(cmd[j].id);
                                ok1 = true;
                            }
                        }
                        j = j + 1;
                        if (j == cantitate)
                        {

                            foreach (var z in cautare)
                                slabs.Add(cmd[z - 1]);
                            if (Conditie(slabs, parinti, cmd))
                            {
                                ordine.Clear();
                                placiTaiate = 0;
                                pierderLat = 0;
                                pierderLng = 0;
                                foreach (var z in cautare)
                                {
                                    newLat = 5;
                                    newLng = 5;
                                    idPlacaTaiata = 0;
                                    foreach (var z1 in stoc)
                                    {
                                        
                                        if (cmd[z - 1].lungime <= z1.Lungime && cmd[z - 1].latime <= z1.Latime)
                                        {
                                            ok1 = false;
                                            foreach (var z2 in ordine)
                                                if (z2 == z1.IdSS)
                                                    ok1 = true;
                                            
                                            if (z1.Lungime - cmd[z - 1].lungime < newLng && ok1 == false)
                                            {
                                                newLng = z1.Lungime - cmd[z - 1].lungime;
                                                newLat = z1.Latime - cmd[z - 1].latime;
                                                idPlacaTaiata = z1.IdSS;
                                            }
                                            
                                            if (z1.Lungime - cmd[z - 1].lungime == newLng && ok1 == false)
                                            {
                                                
                                                if (z1.Latime - cmd[z - 1].latime < newLat)
                                                {
                                                    newLng = z1.Lungime - cmd[z - 1].lungime;
                                                    newLat = z1.Latime - cmd[z - 1].latime;
                                                    idPlacaTaiata = z1.IdSS;
                                                }
                                            }
                                        }
                                        
                                    }
                                    if (newLng != 0 || newLat != 0)
                                    {
                                        if(newLng != 5 && newLat != 5)
                                            placiTaiate++;
                                        
                                        if (newLng < 0.1 && newLng > 0)
                                        {
                                            pierderLng = pierderLng + newLng;
                                            pierderLat = pierderLat + newLat;
                                        }
                                        else
                                        {
                                            if (newLat < 0.1 && newLat > 0)
                                            {
                                                pierderLng = pierderLng + newLng;
                                                pierderLat = pierderLat + newLat;
                                            }
                                        }


                                    }

                                    
                                    ordine.Add(idPlacaTaiata);
                                }
                                okZero = 0;
                                foreach (var zer in ordine)
                                    if (zer == 0)
                                        okZero++;
                                
                                if (okZero <= zero)
                                {
                                    zero = okZero;
                                    if (pierderLng == 0 && pierderLat == 0)
                                    {
                                        if (placiTaiate < PlaciTaiate)
                                        {
                                            
                                            PlaciFinale.Clear();
                                            StocFinal.Clear();
                                            foreach (var z in cautare)
                                            {
                                                PlaciFinale.Add(z);
                                            }
                                            foreach (var z2 in ordine)
                                            {
                                                StocFinal.Add(z2);
                                            }
                                            lng = pierderLng;
                                            lat = pierderLat;
                                            PlaciTaiate = placiTaiate;
                                        }
                                    }
                                    else
                                    {
                                        if (pierderLng < lng && pierderLat < lat)
                                        {
                                            //Facem schema here
                                            PlaciFinale.Clear();
                                            StocFinal.Clear();
                                            foreach (var z in cautare)
                                            {
                                                PlaciFinale.Add(z);
                                            }
                                            foreach (var z2 in ordine)
                                            {
                                                StocFinal.Add(z2);
                                            }
                                            lng = pierderLng;
                                            lat = pierderLat;
                                            PlaciTaiate = placiTaiate;
                                        }
                                        else
                                        {
                                            if (pierderLng < lng && pierderLat > lat)
                                            {
                                                sumLng = lng - pierderLng;
                                                sumLat = pierderLat - lat;
                                                if (sumLng > sumLat)
                                                {
                                                    //facem schema si aici
                                                    PlaciFinale.Clear();
                                                    StocFinal.Clear();
                                                    foreach (var z in cautare)
                                                    {
                                                        PlaciFinale.Add(z);
                                                    }
                                                    foreach (var z2 in ordine)
                                                    {
                                                        StocFinal.Add(z2);
                                                    }
                                                    lng = pierderLng;
                                                    lat = pierderLat;
                                                    PlaciTaiate = placiTaiate;
                                                }
                                            }
                                            else
                                            {
                                                if (pierderLng > lng && pierderLat < lat)
                                                {
                                                    sumLng = pierderLng - lng;
                                                    sumLat = lat - pierderLat;
                                                    if (sumLat < sumLng)
                                                    {
                                                        //facem schema si aici
                                                        PlaciFinale.Clear();
                                                        StocFinal.Clear();
                                                        foreach (var z in cautare)
                                                        {
                                                            PlaciFinale.Add(z);
                                                        }
                                                        foreach (var z2 in ordine)
                                                        {
                                                            StocFinal.Add(z2);
                                                        }
                                                        lng = pierderLng;
                                                        lat = pierderLat;
                                                        PlaciTaiate = placiTaiate;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                



                            }
                            slabs.Clear();
                            int cc = cautare.Count - 1;
                            j = cautare[cc];
                            cautare.RemoveAt(cautare.Count - 1);
                            if(j == cmd[cmd.Count - 1].id)
                            {
                                cc = cautare.Count - 1;
                                j = cautare[cc];
                                cautare.RemoveAt(cautare.Count - 1);
                            }
                            newCant = cautare.Count;
                            


                        }
                        newCant = cautare.Count;


                    }
                }
                else
                {
                    
                    if (newCant!=0)
                    {
                      
                        foreach (var z in cautare)
                            slabs.Add(cmd[z - 1]);
                        
                        if (Conditie(slabs, parinti, cmd))
                        {
                            
                            placiTaiate = 0;
                            pierderLat = 0;
                            pierderLng = 0;
                            ordine.Clear();
                            foreach (var z in cautare)
                            {
                                newLat = 5;
                                newLng = 5;
                                idPlacaTaiata = 0;
                                
                                foreach (var z1 in stoc)
                                {
                                    //Console.WriteLine(z + " " + cmd[z - 1].id + " " + z1.id);
                                    if (cmd[z - 1].lungime <= z1.Lungime && cmd[z - 1].latime <= z1.Latime)
                                    {
                                        ok1 = false;
                                        foreach (var z2 in ordine)
                                            if (z2 == z1.IdSS)
                                                ok1 = true;
                                        //Console.WriteLine(ok1);
                                        if (z1.Lungime - cmd[z - 1].lungime < newLng && ok1 == false)
                                        {
                                            newLng = z1.Lungime - cmd[z - 1].lungime;
                                            newLat = z1.Latime - cmd[z - 1].latime;
                                            idPlacaTaiata = z1.IdSS;
                                        }
                                        if (z1.Lungime - cmd[z - 1].lungime == newLng && ok1 == false)
                                        {
                                            if (z1.Latime - cmd[z - 1].latime < newLat)
                                            {
                                                newLng = z1.Lungime - cmd[z - 1].lungime;
                                                newLat = z1.Latime - cmd[z - 1].latime;
                                                idPlacaTaiata = z1.IdSS;
                                            }
                                        }
                                    }

                                }
                                if (newLng != 0 || newLat != 0)
                                {
                                    placiTaiate++;
                                    if (newLng != 0 && newLat != 0)
                                    {
                                        if (newLng < 0.1 || newLat < 0.1)
                                        {

                                            pierderLng = pierderLng + newLng;
                                            pierderLat = pierderLat + newLat;
                                        }
                                    }
                                }
                                
                                ordine.Add(idPlacaTaiata);
                            }
                            
                            okZero = 0;
                            foreach (var zer in ordine)
                                if (zer == 0)
                                    okZero++;
                            if (okZero <= zero )
                            {
                                zero = okZero;
                                if (pierderLng == 0 && pierderLat == 0)
                                {
                                    if (placiTaiate < PlaciTaiate)
                                    {
                                        //Asta e schema
                                        PlaciFinale.Clear();
                                        StocFinal.Clear();
                                        foreach (var z in cautare)
                                        {
                                            PlaciFinale.Add(z);
                                        }
                                        foreach (var z2 in ordine)
                                        {
                                            StocFinal.Add(z2);
                                        }
                                        lng = pierderLng;
                                        lat = pierderLat;
                                        PlaciTaiate = placiTaiate;
                                    }
                                }
                                else
                                {
                                    if (pierderLng < lng && pierderLat < lat)
                                    {
                                        //Facem schema here
                                        PlaciFinale.Clear();
                                        StocFinal.Clear();
                                        foreach (var z in cautare)
                                        {
                                            PlaciFinale.Add(z);
                                        }
                                        foreach (var z2 in ordine)
                                        {
                                            StocFinal.Add(z2);
                                        }
                                        lng = pierderLng;
                                        lat = pierderLat;
                                        PlaciTaiate = placiTaiate;
                                    }
                                    else
                                    {
                                        if (pierderLng < lng && pierderLat > lat)
                                        {
                                            sumLng = lng - pierderLng;
                                            sumLat = pierderLat - lat;
                                            if (sumLng > sumLat)
                                            {
                                                //facem schema si aici
                                                PlaciFinale.Clear();
                                                StocFinal.Clear();
                                                foreach (var z in cautare)
                                                {
                                                    PlaciFinale.Add(z);
                                                }
                                                foreach (var z2 in ordine)
                                                {
                                                    StocFinal.Add(z2);
                                                }
                                                lng = pierderLng;
                                                lat = pierderLat;
                                                PlaciTaiate = placiTaiate;
                                            }
                                        }
                                        else
                                        {
                                            if (pierderLng > lng && pierderLat < lat)
                                            {
                                                sumLng = pierderLng - lng;
                                                sumLat = lat - pierderLat;
                                                if (sumLat < sumLng)
                                                {
                                                    //facem schema si aici
                                                    PlaciFinale.Clear();
                                                    StocFinal.Clear();
                                                    foreach (var z in cautare)
                                                    {
                                                        PlaciFinale.Add(z);
                                                    }
                                                    foreach (var z2 in ordine)
                                                    {
                                                        StocFinal.Add(z2);
                                                    }
                                                    lng = pierderLng;
                                                    lat = pierderLat;
                                                    PlaciTaiate = placiTaiate;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        slabs.Clear();
                        int cc = cautare.Count - 1;
                        j = cautare[cc];

                        cautare.RemoveAt(cautare.Count - 1);
                        newCant = cautare.Count;
                    }
                }
                i++;
            }


            var SlabsR = new SlabReturned();
            //Facem update la placi
            int fin = 0;
            zero = 0;
            
            foreach(var z2 in StocFinal)
            {
                
                if(z2 == 0)
                    zero++;
            }
            
            if(zero == 0)
            {   
                
                while (fin < PlaciFinale.Count)
                {
                    
                    
                    // De exclus pierderea!! -- Verificat
                    var SlabStocFinal = _repositoryStoc.GetSlabStocById(StocFinal[fin]);
                    
                    if(cmd[PlaciFinale[fin]-1].lungime < SlabStocFinal.Lungime)
                    {
                        var LS = SlabStocFinal.Lungime;
                        var LC = cmd[PlaciFinale[fin]-1].lungime;

                        var latC = cmd[PlaciFinale[fin]-1].latime;
                        var MS = SlabStocFinal.Material;
                        var dif = LS - LC;
                        
                        if(dif >= 0.10 && latC >= 0.10)
                        {
                            var IndexRL = _repositoryStoc.CreateSlabStocReturnId(new SlabStoc(dif,latC,MS));
                            SlabsR.IdSN.Add(IndexRL);
                            _repositoryStoc.SaveChanges();
                        }

                        //Adaugam placa nou in stoc de Lungime = dif dintre * si latimea = cmd[x].latime
                        
                    }
                    if(cmd[PlaciFinale[fin]-1].latime < SlabStocFinal.Latime)
                    {
                        var latC = cmd[PlaciFinale[fin]-1].latime;
                        var latS = SlabStocFinal.Latime;
                        var dif = latS - latC;
                        var LS = SlabStocFinal.Lungime;
                        var MS = SlabStocFinal.Material;

                        if(dif >= 0.10 && LS >= 0.10)
                        {
                            var IndexRL = _repositoryStoc.CreateSlabStocReturnId(new SlabStoc(LS,dif,MS));
                            SlabsR.IdSN.Add(IndexRL);
                            _repositoryStoc.SaveChanges();
                        }

                        // Adaugam placa nou in stoc de Lungime = stoc[x].Lungime si latimea = dif dintre *
                    }
                    fin++;
                }

            }



            fin = 0;

            List<SlabComandaMod> newParcurgere = new List<SlabComandaMod>();
            List<int> firstSlab = new List<int>();
            while (fin < PlaciFinale.Count)
            {
                newParcurgere.Clear();
                firstSlab.Clear();
                parcurgere.Clear();
                int k = 0;
                parcurgere.Add(cmd[PlaciFinale[fin]-1]);
                k = 0;
                int cant = parcurgere.Count;
                while (k < cant)
                {
                    if (parcurgere[k].id1 != 0)
                    {
                        parcurgere.Add(cmd[parcurgere[k].id1 - 1]);
                        parcurgere.Add(cmd[parcurgere[k].id2 - 1]);
                        cant++;
                        cant++;
                    }
                    else
                    {
                        firstSlab.Add(parcurgere[k].id);
                    }
                    k++;
                }
                foreach (var fina in firstSlab)
                {
                    
                    cmd[fina-1].idPlacaStoc = StocFinal[fin];
                }
                fin++;
            }
            
            if(zero == 0)
            {  
                Console.WriteLine("Placile in stadiul final");
                foreach (var g in cmd)
                    if (g.id1 == 0)
                    {
                        Console.WriteLine(g);
                        SlabsR.IdSC.Add(g.idBun);
                        SlabsR.IdSS.Add(g.idPlacaStoc);
                    }
            }
                
            //facem update-ul in baza de date
            /*foreach (var g in cmd)
                if (g.id1 == 0)
                {
                    var plc = _repositoryComanda.GetSlabComandaById(g.idBun);
                    _repositoryComanda.UpdateSlabComanda(plc, g.idPlacaStoc);
                    var plcStoc = _repositoryStoc.GetSlabStocById(g.idPlacaStoc);
                    _repositoryStoc.UpdateSlabStoc(plcStoc);
                }*/
            Console.WriteLine(SlabsR);
            return SlabsR;
            
            
        }


        public SlabReturned CmdAlgorithmP2(List<SlabComanda> comandaAdusa, List<SlabStoc> noustoc)
        {
            var SlabsR = new SlabReturned();
            List<SlabStoc> stoc = new List<SlabStoc>();
            List<SlabComandaMod> cmd = new List<SlabComandaMod>();
            List<int> parinti = new List<int>();

            int indexBun = 1;
            foreach(var ceva in comandaAdusa)
            {
                cmd.Add(new SlabComandaMod(indexBun,ceva.Lungime,ceva.Latime,ceva.IdSC));
                parinti.Add(indexBun);
                indexBun ++;
            }
            foreach(var ceva in noustoc)
                stoc.Add(ceva);
            //Initializam ID-ul pentru prima placa pe care o vom "construi"
            int newId = cmd[cmd.Count-1].id+1;
            
            int i = 0;
            int j = 0;
            //Afisam stocul
            foreach(var z in stoc)
                Console.WriteLine(z);
            Console.WriteLine(" ");

            //Sortarea in functie de lungime si apoi de lantime
            SlabComandaMod aux = new SlabComandaMod();
            while(i < cmd.Count)
            {
                j = i + 1;
                while(j < cmd.Count)
                {
                    if(cmd[i].lungime < cmd[j].lungime)
                    {
                        aux = cmd[i];
                        cmd[i] = cmd[j];
                        cmd[j] = aux;
                        i = 0;
                        j = 0;
                    } 
                    else
                    {
                        if (cmd[i].lungime == cmd[j].lungime)
                        {
                            if (cmd[i].latime < cmd[j].latime)
                            {
                                aux = cmd[i];
                                cmd[i] = cmd[j];
                                cmd[j] = aux;
                                i = 0;
                                j = 0;
                            }
                        }
                    }

                    j++;
                }
                i++;
            }
            i = 0;
            double lng = 5.0;
            double lat = 0.5;
            int newIndex = 0;
            bool ok = false;
            while(i < cmd.Count)
            {
                lng = 5.0;
                lat = 5.0;
                newIndex = 0;
                List<int> newIndexs = new List<int>();
                foreach( var z in stoc)
                {
                    ok = false;
                    if(z.Lungime - cmd[i].lungime <= lng && z.Lungime - cmd[i].lungime >= 0)
                    {
                        if(z.Latime - cmd[i].latime <= lat && z.Latime - cmd[i].latime >= 0)
                        {
                            foreach(var z1 in newIndexs)
                            {
                                if(z1 == z.IdSS)
                                    ok = true;
                            }
                            if(ok == false)
                            {
                                newIndex = z.IdSS;
                                lng = z.Lungime - cmd[i].lungime;
                                lat = z.Latime - cmd[i].latime;

                            }
                        }
                    }
                }
                if(newIndex != 0)
                    newIndexs.Add(newIndex);
                cmd[i].idPlacaStoc = newIndex;
                if(newIndex != 0)
                {
                    var SlabStocFinal = _repositoryStoc.GetSlabStocById(newIndex);
                    if(cmd[i].lungime < SlabStocFinal.Lungime)
                    {
                        var LS = SlabStocFinal.Lungime;
                        var LC = cmd[i].lungime;

                        var latC = cmd[i].latime;
                        var MS = SlabStocFinal.Material;
                        var dif = LS - LC;
                        
                        if(dif >= 0.10 && latC >= 0.10)
                        {
                            var IndexRL = _repositoryStoc.CreateSlabStocReturnId(new SlabStoc(dif,latC,MS));
                            Console.WriteLine("Aici!!");
                            Console.WriteLine("Aici avem indexul returnat: " + IndexRL);
                            SlabsR.IdSN.Add(IndexRL);
                            _repositoryStoc.SaveChanges();
                            var SlabStocCreata = _repositoryStoc.GetSlabStocById(IndexRL);
                            Console.WriteLine("Aici avem placa returnata dupa index: " + SlabStocCreata);
                            stoc.Add(SlabStocCreata);
                        }

                        //Adaugam placa nou in stoc de Lungime = dif dintre * si latimea = cmd[x].latime
                        
                    }
                    if(cmd[i].latime < SlabStocFinal.Latime)
                    {
                        var latC = cmd[i].latime;
                        var latS = SlabStocFinal.Latime;
                        var dif = latS - latC;
                        var LS = SlabStocFinal.Lungime;
                        var MS = SlabStocFinal.Material;

                        if(dif >= 0.10 && LS >= 0.10)
                        {
                            var IndexRL = _repositoryStoc.CreateSlabStocReturnId(new SlabStoc(LS,dif,MS));
                            Console.WriteLine("Aici!!");
                            Console.WriteLine("Aici avem indexul returnat: " + IndexRL);
                            SlabsR.IdSN.Add(IndexRL);
                            _repositoryStoc.SaveChanges();
                            var SlabStocCreata = _repositoryStoc.GetSlabStocById(IndexRL);
                            Console.WriteLine("Aici avem placa returnata dupa index: " + SlabStocCreata);
                            stoc.Add(SlabStocCreata);
                        }

                        // Adaugam placa nou in stoc de Lungime = stoc[x].Lungime si latimea = dif dintre *
                    }

                }
                //trebuie sa fac dif dintre placi 

                i++;
            }
            
            foreach (var g in cmd)
                if (g.id1 == 0)
                {
                    Console.WriteLine(g);
                    SlabsR.IdSC.Add(g.idBun);
                    SlabsR.IdSS.Add(g.idPlacaStoc);
                }


            Console.WriteLine(SlabsR);
            return SlabsR;
        }
        
        public List<int> CutSlabs (int id)
        {
            List<SlabReturned> stoc = new List<SlabReturned>();
            
            List<SlabStoc> ceva = new List<SlabStoc>();
            List<SlabComanda> altceva = new List<SlabComanda>();
            List<string> listMaterial = _repositoryComanda.GetMaterialByIdComanda(id);
            bool ok = true;
            int zero = 0;
            var verf = new SlabReturned();
            List<int> IdPlaciReturnate = new List<int>();
            foreach(var z in listMaterial)
            {
                zero = 0;
                if(ok == true)
                {
                    ceva = _repositoryStoc.GetSlabStocByMaterialLungimeLatime(z,0.1,0.1); //De modificat si de obtinut lungimea minima / latimea minima
                    altceva = _repositoryComanda.GetSlabStocByMaterialIdComanda(z,id); 
                    verf = CmdAlgorithm(altceva,ceva);
                    if (verf.IdSC.Count == 0)
                    {
                        verf = CmdAlgorithmP2(altceva, ceva);
                        
                        foreach( var v in verf.IdSS)
                        {   
                            
                            if(v == 0)
                                zero = zero + 1;
                        }
                        if (zero != 0) //Gasim alta conditie !! Ca sa ne putem pastra placile care trebuie returnate -- Am gasit
                        {   
                            ok = false;
                            //Problema este ca ne vom opri la primul material pentru care nu gasim placi in stoc
                            //Si vom returna doar acele placi fara sa mai verificam si restul placilor din material dif.
                        }
                        
                    }
                    
                    if(ok == true)
                        stoc.Add(verf);
                }
            }
            int i = 0;
            if(ok == false)
            {
                //Facem undo pentru tot ce este in "stoc";
                //In "verf" vom avea toate placile din acel material pentru care nu s-a gasit corespondent in stoc
                foreach(var i1 in stoc)
                {
                    foreach(var i4 in i1.IdSN)
                    {
                        
                        _repositoryStoc.DeleteSlabStoc(_repositoryStoc.GetSlabStocById(i4));
                        _repositoryStoc.SaveChanges();

                    }
                    
                }
                var cant = verf.IdSC.Count;
                while( i < cant)
                {
                        if(verf.IdSS[i] == 0)
                            IdPlaciReturnate.Add(verf.IdSC[i]);
                        
                        i++;

                 }
                
            }
            i = 0;
            if(ok == true)
            {
                // Facem update in baza de date pentru placile din comanda si cele din stoc
                foreach(var i1 in stoc)
                {
                    var cant = i1.IdSC.Count;
                    i = 0;
                    while( i < cant)
                    {
                        
                        var plc = _repositoryComanda.GetSlabComandaById(i1.IdSC[i]);
                        _repositoryComanda.UpdateSlabComanda(plc, i1.IdSS[i]);
                        var plcStoc = _repositoryStoc.GetSlabStocById(i1.IdSS[i]);
                        _repositoryStoc.UpdateSlabStoc(plcStoc);
                        i++;

                    }
                   
                }


            }

            return IdPlaciReturnate;                
            
        }
    }
}




