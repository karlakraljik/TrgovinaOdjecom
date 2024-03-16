namespace Backend.Models
{
    public class Proizvod : Entitet
    {
        public string? Naziv { get; set; }
        public DateTime? Datumnabave { get; set; }
        public decimal? Cijena { get; set; }
        public bool? Aktivan { get; set; }
    }
}

