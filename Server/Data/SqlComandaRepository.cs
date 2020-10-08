using System;
using System.Collections.Generic;
using System.Linq;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public class SqlComandaRepository : IComandaRepository
    {
        private readonly CommanderContext _context;

        public SqlComandaRepository(CommanderContext context)
        {
            _context = context;
        }

        public void CreateComanda(Comanda cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            cmd.Done = false;
            _context.Comanda.Add(cmd);
        }

        public void DeleteComanda(Comanda cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            
            _context.Comanda.Remove(cmd);
        }

        public IEnumerable<Comanda> GetAllComandsById(int id)
        {
            return _context.Comanda.Where(p => p.Id == id).ToList();
            
        }

        public Comanda GetComandaById(int id)
        {
            return _context.Comanda.FirstOrDefault(p => p.IdC == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateComanda(Comanda cmd)
        {
            
        }
    }
}