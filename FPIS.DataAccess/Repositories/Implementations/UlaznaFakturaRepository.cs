using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FPIS.DataAccess.Repositories.Implementations
{
    public class UlaznaFakturaRepository : GenericRepository<UlaznaFaktura>, IUlaznaFakturaRepository
    {
        public UlaznaFakturaRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<UlaznaFaktura> Search(string searchTerm, int status)
        {
            var result = _context.UlaznaFaktura
                .Include(x => x.StavkeUlazneFakture).ThenInclude(y => y.Proizvod)
                .Where(x => searchTerm == null || (x.Id.ToString().Contains(searchTerm)))
                .Where(x => status == -1 || (int)x.Status == status);

            return result;
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
    }
}
