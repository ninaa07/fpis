using System.Collections.Generic;

namespace FPIS.Domain
{
    public class Grad: BaseEntity
    {
        public string Naziv { get; set; }

        public int DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }

        public virtual ICollection<Ulica> Ulice { get; set; } = new HashSet<Ulica>();

        public virtual ICollection<Dobavljac> Dobavljaci { get; set; } = new HashSet<Dobavljac>();
    }
}
