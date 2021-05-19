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
            return _context.UlaznaFaktura.Include(x => x.StavkeUlazneFakture);
        }
    }
}
