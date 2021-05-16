using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FPIS.DataAccess.Repositories.Implementations
{
    public class DobavljacRepository : GenericRepository<Dobavljac>, IDobavljacRepository
    {
        public DobavljacRepository(ApplicationContext context) : base(context)
        {

        }

        public IEnumerable<Dobavljac> GetAllDobavljaci()
        {
            return _context.Dobavljac.Include(x => x.Ulica);
        }
        public IEnumerable<Drzava> GetAllDrzava()
        {
            return _context.Drzava;
        }
        public IEnumerable<Ulica> GetAllUlica()
        {
            return _context.Ulica;
        }
        public IEnumerable<Grad> GetAllGrad()
        {
            return _context.Grad;
        }
    }
}
