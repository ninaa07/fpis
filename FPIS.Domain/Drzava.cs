using System.Collections.Generic;

namespace FPIS.Domain
{
    public class Drzava: BaseEntity
    {
        public string Naziv { get; set; }

        public virtual ICollection<Grad> Gradovi { get; set; } = new HashSet<Grad>();

        public virtual ICollection<Dobavljac> Dobavljaci { get; set; } = new HashSet<Dobavljac>();
    }
}
