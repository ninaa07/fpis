using System.Collections.Generic;

namespace FPIS.Domain
{
    public class Dobavljac: BaseEntity
    {
        public string Naziv { get; set; }

        public int DrzavaId { get; set; }

        public int GradId { get; set; }

        public int UlicaId { get; set; }

        public int RangId { get; set; }

        public virtual Drzava Drzava { get; set; }

        public virtual Ulica Ulica { get; set; }

        public virtual Grad Grad { get; set; }

        public virtual Rang Rang { get; set; }

        public virtual ICollection<PackingLista> PackingListe { get; set; } = new HashSet<PackingLista>();
    }
}
