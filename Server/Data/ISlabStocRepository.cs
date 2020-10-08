using System.Collections.Generic;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public interface ISlabStocRepository
    {
        bool SaveChanges();
        SlabStoc GetSlabStocById(int id);
        void CreateSlabStoc(SlabStoc cmd);
        int CreateSlabStocReturnId(SlabStoc cmd);
        void UpdateSlabStoc(SlabStoc cmd);
        void DeleteSlabStoc(SlabStoc com);

        List<SlabStoc> GetSlabStocByMaterialLungimeLatime(string material, double lungime, double latime);
        List<SlabStoc> GetSlabStocByMaterial(string material);
        
        
    }
}