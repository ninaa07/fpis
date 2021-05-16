using System;
using System.Collections.Generic;

namespace FPIS.Domain
{
    public class UlaznaFaktura : BaseEntity
    {
        public int Tezina { get; set; }

        public int Iznos { get; set; }

        public DateTime Datum { get; set; }

        public Status Status { get; set; }

        public int PackingListaId { get; set; }

        public virtual PackingLista PackingLista { get; set; }

        public virtual ICollection<StavkaUlazneFakture> StavkeUlazneFakture { get; set; } = new HashSet<StavkaUlazneFakture>();
    }

    public enum Status
    {
        Kreirana,
        Izmenjena,
        Potpisana
    }
}
