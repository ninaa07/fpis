using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FPIS.DataAccess.Repositories.Implementations
{
    public class UlaznaFakturaRepository : GenericRepository<UlaznaFaktura>, IUlaznaFakturaRepository
    {
        public UlaznaFakturaRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<UlaznaFaktura> GetAllUfWithStavke()
        {
            return _context.UlaznaFaktura.Include(x => x.StavkeUlazneFakture).ThenInclude(y => y.Proizvod);
        }

        public IEnumerable<Proizvod> GetAllProizvodi()
        {
            return _context.Proizvod;
        }

        public IEnumerable<PackingLista> GetAllPackingListe()
        {
            return _context.PackingLista;
        }

        public IEnumerable<Rang> GetAllRangovi()
        {
            return _context.Rang;
        }
    }
}
