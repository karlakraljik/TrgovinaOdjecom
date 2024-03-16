using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class TrgovinaOdjecomContext:DbContext
    {
        public TrgovinaOdjecomContext(DbContextOptions<TrgovinaOdjecomContext> options) 
            : base(options){
        }
        public DbSet<Kupac> Kupci {  get; set; }
        public DbSet<Proizvod> Proizvodi { get; set;}
        public DbSet<Racun>Racuni { get; set;}
        public DbSet<Stavka> Stavke { get; set;}

        public DbSet<Osoba> Osobe { get; set;}
        
    }
}
