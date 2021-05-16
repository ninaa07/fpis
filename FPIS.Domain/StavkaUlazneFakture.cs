namespace FPIS.Domain
{
    public class StavkaUlazneFakture
    {
        public int Id { get; set; }

        public int UlaznaFakturaId { get; set; }

        public int Kolicina { get; set; }

        public decimal Iznos { get; set; }

        public int ProizvodId { get; set; }

        public virtual UlaznaFaktura UlaznaFaktura { get; set; }

        public virtual Proizvod Proizvod { get; set; }
    }
}
