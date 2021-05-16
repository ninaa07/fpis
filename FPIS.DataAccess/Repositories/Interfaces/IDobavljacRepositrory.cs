using FPIS.Domain;
using System.Collections.Generic;

namespace FPIS.DataAccess.Repositories.Interfaces
{
    public interface IDobavljacRepository : IGenericRepository<Dobavljac>
    {
        IEnumerable<Dobavljac> GetAllDobavljaci();
        IEnumerable<Drzava> GetAllDrzava();
        IEnumerable<Grad> GetAllGrad();
        IEnumerable<Ulica> GetAllUlica();
    }
}
