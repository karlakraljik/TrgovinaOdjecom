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
    }
}
