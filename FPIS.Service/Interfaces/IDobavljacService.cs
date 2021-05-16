using FPIS.Domain;
using FPIS.Service.Dtos;
using System.Collections.Generic;

namespace FPIS.Service.Interfaces
{
    public interface IDobavljacService
    {
        public IEnumerable<Dobavljac> GetAll();
        public IEnumerable<Drzava> GetAllDrzava();
        public IEnumerable<Grad> GetAllGrad();
        public IEnumerable<Ulica> GetAllUlica();
        public Dobavljac Get(int id);
        public ServiceResult<Dobavljac> Add(Dobavljac dobavljac);
        public ServiceResult<Dobavljac> Update(Dobavljac dobavljac);
        public ServiceResult<Dobavljac> Delete(Dobavljac dobavljac);
    }
}
