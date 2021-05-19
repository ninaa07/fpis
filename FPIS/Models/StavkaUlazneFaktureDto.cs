namespace FPIS.Models
{
    public class StavkaUlazneFaktureDto
    {
        public int Id { get; set; }

        public int UlaznaFakturaId { get; set; }

        public int Kolicina { get; set; }

        public decimal Iznos { get; set; }

        public int ProizvodId { get; set; }
    }
}
