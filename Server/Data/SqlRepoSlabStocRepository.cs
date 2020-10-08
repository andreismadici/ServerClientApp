using System;
using System.Collections.Generic;
using System.Linq;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public class SqlSlabStocRepository : ISlabStocRepository
    {
        private readonly CommanderContext _context;

        public SqlSlabStocRepository(CommanderContext context)
        {
            _context = context;
        }

        public void CreateSlabStoc(SlabStoc cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            cmd.Taken = false;
            _context.SlabStoc.Add(cmd);
        }

        public int CreateSlabStocReturnId(SlabStoc cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            cmd.Taken = false;
            _context.SlabStoc.Add(cmd);
            SaveChanges();
            return cmd.IdSS;
        }

        public void DeleteSlabStoc(SlabStoc com)
        {
            if(com == null)
            {
                throw new ArgumentNullException(nameof(com));
            }
            
            _context.SlabStoc.Remove(com);
        }

        public SlabStoc GetSlabStocById(int id)
        {
            return _context.SlabStoc.FirstOrDefault(p => p.IdSS == id);
        }

        public List<SlabStoc> GetSlabStocByMaterial(string material)
        {
            return _context.SlabStoc.Where(p => p.Material == material).ToList();
        }

        public List<SlabStoc> GetSlabStocByMaterialLungimeLatime(string material, double lungime, double latime)
        {
            return _context.SlabStoc.Where(p => p.Material == material && p.Lungime >= lungime && p.Latime >= latime && p.Taken == false).ToList();
            
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSlabStoc(SlabStoc cmd)
        {
            cmd.Taken = true;
            SaveChanges();
        }
    }
}