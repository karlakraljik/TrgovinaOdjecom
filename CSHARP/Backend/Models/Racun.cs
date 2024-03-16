using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Racun :Entitet
    {
        [ForeignKey("kupci_sifra")]

        public DateTime? Datum { get; set; }
        public int? Kupac { get; set; }

    }
}
