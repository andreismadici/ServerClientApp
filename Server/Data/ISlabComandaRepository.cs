using System.Collections.Generic;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public interface ISlabComandaRepository
    {
        bool SaveChanges();
        SlabComanda GetSlabComandaById(int id);
        void CreateSlabComanda(SlabComanda cmd);
        void UpdateSlabComanda(SlabComanda cmd, int id);
        void DeleteSlabComanda(SlabComanda comanda);
        List<SlabComanda> GetSlabStocByMaterialIdComanda(string material, int idComanda);
        List<SlabComanda> GetAllSlabComandaIdComanda(int idComanda);
        List<string> GetMaterialByIdComanda(int idComanda);

        
        
    }
}