using System.Collections.Generic;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public interface IClientRepository
    {
        bool SaveChanges();
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void CreateClient(Client clnt);
        void UpdateClient(Client clnt);
        void DeleteClient(Client clnt);
        Client LoginClient(Client clnt);
        
    }
}