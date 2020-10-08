using System;
using System.Collections.Generic;
using System.Linq;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly CommanderContext _context;

        public SqlClientRepository(CommanderContext context)
        {
            _context = context;
        }

        public void CreateClient(Client clnt)
        {
            if(clnt == null)
            {
                throw new ArgumentNullException(nameof(clnt));
            }
            var cont =_context.Clients.FirstOrDefault(p => p.Email == clnt.Email);
            if(cont == null)
            {    
                _context.Clients.Add(clnt);
            }
        }

        public void DeleteClient(Client clnt)
        {
            if(clnt == null)
            {
                throw new ArgumentNullException(nameof(clnt));
            }
            _context.Clients.Remove(clnt);
            

        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.FirstOrDefault(p => p.Id == id);
        }

        public Client LoginClient(Client clnt)
        {

            return _context.Clients.FirstOrDefault(p => p.Email == clnt.Email && p.Password == clnt.Password);

            
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateClient(Client clnt)
        {
            
        }
    }
}