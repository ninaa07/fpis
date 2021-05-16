using System.Collections.Generic;

namespace FPIS.Domain
{
    public class Proizvod: BaseEntity
    {
        public string Naziv { get; set; }

        public decimal Cena { get; set; }

        public virtual ICollection<StavkaUlazneFakture> StavkeUlazneFakture { get; set; } = new HashSet<StavkaUlazneFakture>();
    }
}
