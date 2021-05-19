using FPIS.Domain;
using System;

namespace FPIS.Models
{
    public class EditUlaznaFakturaDto
    {
        public int Id { get; set; }
     
        public DateTime Datum { get; set; }

        public Status Status { get; set; }

        public int PackingListaId { get; set; }
    }
}
