using System.Collections.Generic;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public class MockClientRepository : IClientRepository
    {
        public void CreateClient(Client clnt)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteClient(Client clnt)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Client> GetAllClients()
        {
            var clients = new List<Client>
            {
                new Client { Id = 1, Name = "Andrei", Password = "123456"},
                new Client { Id = 2, Name = "Andrei2", Password = "123456"}

            };
            return clients;
        }

        public Client GetClientById(int id)
        {
            return new Client { Id = 0, Name = "Andrei", Password = "123456"};
        }

        public void LoginClient(Client clnt)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateClient(Client clnt)
        {
            throw new System.NotImplementedException();
        }

        Client IClientRepository.LoginClient(Client clnt)
        {
            throw new System.NotImplementedException();
        }
    }
}