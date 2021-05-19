using FPIS.Domain;
using System;
using System.Collections.Generic;

namespace FPIS.Models
{
    public class UlaznaFakturaDto
    {
        public int Tezina { get; set; }

        public int Iznos { get; set; }

        public DateTime Datum { get; set; }

        public Status Status { get; set; }

        public int PackingListaId { get; set; }

        public virtual IEnumerable<StavkaUlazneFakture> StavkeUlazneFakture { get; set; } = new HashSet<StavkaUlazneFakture>();
    }
}
