using FPIS.Domain;
using System.Collections.Generic;

namespace FPIS.Service.Interfaces
{
    public interface IDobavljacService
    {
        public IEnumerable<Dobavljac> Search(string searchTerm);

        public IEnumerable<Drzava> GetAllDrzava();

        public IEnumerable<Grad> GetAllGrad(int drzavaId);

        public IEnumerable<Ulica> GetAllUlica(int gradId);

        IEnumerable<Rang> GetAllRangovi(); public Dobavljac Get(int id);

        public ServiceResult<Dobavljac> Add(Dobavljac dobavljac);

        public ServiceResult<Dobavljac> Update(Dobavljac dobavljac);

        public ServiceResult<Dobavljac> Delete(Dobavljac dobavljac);
    }
}
