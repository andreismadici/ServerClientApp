using Microsoft.EntityFrameworkCore;
using ServerMagazin.Models;

namespace ServerMagazin.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }

        public DbSet<Client> Clients  { get; set; }
        public DbSet<Comanda> Comanda {get; set;}
        public DbSet<SlabStoc> SlabStoc {get; set;}
        public DbSet<SlabComanda> SlabComanda {get; set;}
        public DbSet<SlabComandaMod> SlabComandaMod {get; set;}


    }
}