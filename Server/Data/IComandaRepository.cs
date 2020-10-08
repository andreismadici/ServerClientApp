using System.Collections.Generic;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public interface IComandaRepository
    {
        bool SaveChanges();
        IEnumerable<Comanda> GetAllComandsById(int id);
        Comanda GetComandaById(int id);
        void CreateComanda(Comanda cmd);
        void UpdateComanda(Comanda cmd);
        void DeleteComanda(Comanda cmd);
        
        
    }
}