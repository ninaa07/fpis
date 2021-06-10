using FPIS.Domain;
using System.Collections.Generic;

namespace FPIS.DataAccess.Repositories.Interfaces
{
    public interface IDobavljacRepository : IGenericRepository<Dobavljac>
    {
        IEnumerable<Dobavljac> Search(string searchTerm);

        Dobavljac GetDobavljac(int id);

        IEnumerable<Drzava> GetAllDrzava();

        IEnumerable<Grad> GetAllGrad(int drzavaId);

        IEnumerable<Ulica> GetAllUlica(int gradId);

        IEnumerable<Rang> GetAllRangovi();
    }
}
