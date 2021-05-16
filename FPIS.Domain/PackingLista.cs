using System;
using System.Collections.Generic;

namespace FPIS.Domain
{
    public class PackingLista : BaseEntity
    {
        public int Kolicina { get; set; }

        public int Tezina { get; set; }

        public DateTime Datum { get; set; }

        public int DobavljacId { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }

        public virtual ICollection<UlaznaFaktura> UlazneFakture { get; set; } = new HashSet<UlaznaFaktura>();
    }
}
