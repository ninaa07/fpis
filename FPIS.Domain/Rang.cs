using System.Collections.Generic;

namespace FPIS.Domain
{
    public class Rang: BaseEntity
    {
        public string Oznaka { get; set; }

        public virtual ICollection<Dobavljac> Dobavljaci { get; set; } = new HashSet<Dobavljac>();
    }
}
