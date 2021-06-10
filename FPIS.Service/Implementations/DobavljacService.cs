using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using FPIS.Service.Interfaces;
using System.Collections.Generic;

namespace FPIS.Service.Implementations
{
    public class DobavljacService : IDobavljacService
    {
        private readonly IDobavljacRepository _dobavljacRepository;

        public DobavljacService(IDobavljacRepository dobavljacRepository)
        {
            _dobavljacRepository = dobavljacRepository;
        }

        public IEnumerable<Dobavljac> Search(string searchTerm)
        {
            return _dobavljacRepository.Search(searchTerm);
        }

        public IEnumerable<Drzava> GetAllDrzava()
        {
            return _dobavljacRepository.GetAllDrzava();
        }

        public IEnumerable<Grad> GetAllGrad(int drzavaId)
        {
            return _dobavljacRepository.GetAllGrad(drzavaId);
        }

        public IEnumerable<Ulica> GetAllUlica(int gradId)
        {
            return _dobavljacRepository.GetAllUlica(gradId);
        }

        public IEnumerable<Rang> GetAllRangovi()
        {
            return _dobavljacRepository.GetAllRangovi();
        }

        public Dobavljac Get(int id)
        {
            return _dobavljacRepository.GetDobavljac(id);
        }

        public ServiceResult<Dobavljac> Add(Dobavljac dobavljac)
        {
            _dobavljacRepository.Add(dobavljac);

            _dobavljacRepository.SaveChanges();

            return new ServiceResult<Dobavljac>(true, "Dobavljac uspesno dodat.", Get(dobavljac.Id));
        }

        public ServiceResult<Dobavljac> Update(Dobavljac dobavljac)
        {
            _dobavljacRepository.Update(dobavljac);

            _dobavljacRepository.SaveChanges();

            return new ServiceResult<Dobavljac>(true, "Dobavljac uspesno izmenjen.", Get(dobavljac.Id));
        }

        public ServiceResult<Dobavljac> Delete(Dobavljac dobavljac)
        {
            _dobavljacRepository.Delete(dobavljac);

            _dobavljacRepository.SaveChanges();

            return new ServiceResult<Dobavljac>(true, "Dobavljac uspesno izbrisan.", dobavljac);
        }
    }
}
