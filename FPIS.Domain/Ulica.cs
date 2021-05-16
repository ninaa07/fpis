using System.Collections.Generic;

namespace FPIS.Domain
{
    public class Ulica : BaseEntity
    {
        public string Naziv { get; set; }

        public int DrzavaId { get; set; }

        public int GradId { get; set; }

        public virtual Drzava Drzava { get; set; }

        public virtual Grad Grad { get; set; }

        public virtual ICollection<Dobavljac> Dobavljaci { get; set; } = new HashSet<Dobavljac>();
    }
}
