using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Backend.Models
{
    public class Stavka : Entitet
    {

        [ForeignKey("proizvod_sifra")]
        public Proizvod? proizvod { get; set; }
        [ForeignKey("racun_sifra")]
        public int? Racun { get; set; }
        public int? Kupac { get; set; }
        public int? Proizvod { get; set; }
        public int? Kolicina { get; set; }
        public Decimal? Cijena { get; set; }
    }
}
