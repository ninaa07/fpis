namespace FPIS.Domain
{
    public enum StatusStavke
    {
        None,
        Insert,
        Update,
        Delete
    }

    public class StavkaUlazneFakture : BaseEntity
    {
        public int UlaznaFakturaId { get; set; }

        public int Kolicina { get; set; }

        public decimal Iznos { get; set; }

        public int ProizvodId { get; set; }

        public virtual UlaznaFaktura UlaznaFaktura { get; set; }

        public virtual Proizvod Proizvod { get; set; }

        public StatusStavke StatusStavke { get; set; }
    }
}
