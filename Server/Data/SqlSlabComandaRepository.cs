using System;
using System.Collections.Generic;
using System.Linq;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public class SqlSlabComandaRepository : ISlabComandaRepository
    {
        private readonly CommanderContext _context;

        public SqlSlabComandaRepository(CommanderContext context)
        {
            _context = context;
        }

        public void CreateSlabComanda(SlabComanda cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            cmd.IdSS = 0;
            _context.SlabComanda.Add(cmd);
        }

        public void DeleteSlabComanda(SlabComanda cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            
            _context.SlabComanda.Remove(cmd);
        }

        public List<string> GetMaterialByIdComanda(int idComanda)
        {
            return _context.SlabComanda.Where(p => p.IdC == idComanda).Select(m => m.Material).Distinct().ToList();
        }

        public SlabComanda GetSlabComandaById(int id)
        {
            return _context.SlabComanda.FirstOrDefault(p => p.IdSC == id);
        }

        public List<SlabComanda> GetAllSlabComandaIdComanda(int idComanda)
        {
            return _context.SlabComanda.Where(p => p.IdC == idComanda).ToList();
        }

        public List<SlabComanda> GetSlabStocByMaterialIdComanda(string material, int idComanda)
        {
            return _context.SlabComanda.Where(p => p.Material == material && p.IdC == idComanda).ToList();
        }
        

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSlabComanda(SlabComanda cmd , int id)
        {
            cmd.IdSS = id;
            SaveChanges();
        }
    }
}