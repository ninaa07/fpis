using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FPIS.DataAccess.Repositories.Implementations
{
    public class DobavljacRepository : GenericRepository<Dobavljac>, IDobavljacRepository
    {
        public DobavljacRepository(ApplicationContext context) : base(context)
        {

        }

        public IEnumerable<Dobavljac> Search(string searchTerm)
        {
            var result = _context.Dobavljac
                .Include(x => x.Rang)
                .Include(x => x.Ulica)
                .Include(x => x.Grad)
                .Include(x => x.Drzava)
                .Where(x => searchTerm == null || (x.Naziv.Contains(searchTerm) || x.Rang.Oznaka.Contains(searchTerm) || x.Ulica.Naziv.Contains(searchTerm) || x.Grad.Naziv.Contains(searchTerm) || x.Drzava.Naziv.Contains(searchTerm)));

            return result;
        }

        public Dobavljac GetDobavljac(int id)
        {
            return _context.Dobavljac
                .Include(x => x.Rang)
                .Include(x => x.Ulica)
                .Include(x => x.Grad)
                .Include(x => x.Drzava)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Drzava> GetAllDrzava()
        {
            return _context.Drzava;
        }

        public IEnumerable<Ulica> GetAllUlica(int gradId)
        {
            return _context.Ulica.Where(x => x.GradId == gradId);
        }

        public IEnumerable<Grad> GetAllGrad(int drzavaId)
        {
            return _context.Grad.Where(x => x.DrzavaId == drzavaId);
        }

        public IEnumerable<Rang> GetAllRangovi()
        {
            return _context.Rang;
        }
    }
}
