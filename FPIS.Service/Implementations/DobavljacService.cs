using AutoMapper;
using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using FPIS.Service.Dtos;
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

        public IEnumerable<Dobavljac> GetAll()
        {
            return _dobavljacRepository.GetAll();
        }

        public IEnumerable<Drzava> GetAllDrzava()
        {
            return _dobavljacRepository.GetAllDrzava();
        }
        public IEnumerable<Grad> GetAllGrad()
        {
            return _dobavljacRepository.GetAllGrad();
        }

        public IEnumerable<Ulica> GetAllUlica()
        {
            return _dobavljacRepository.GetAllUlica();
        }

        public Dobavljac Get(int id)
        {
            return _dobavljacRepository.Get(id);
        }

        public ServiceResult<Dobavljac> Add(Dobavljac dobavljac)
        {
            _dobavljacRepository.Add(dobavljac);

            _dobavljacRepository.SaveChanges();

            return new ServiceResult<Dobavljac>(true, "Dobavljac uspesno dodat.", dobavljac);
        }

        public ServiceResult<Dobavljac> Update(Dobavljac dobavljac)
        {
            _dobavljacRepository.Update(dobavljac);

            _dobavljacRepository.SaveChanges();

            return new ServiceResult<Dobavljac>(true, "Dobavljac uspesno izmenjen.", dobavljac);
        }

        public ServiceResult<Dobavljac> Delete(Dobavljac dobavljac)
        {
            _dobavljacRepository.Delete(dobavljac);

            _dobavljacRepository.SaveChanges();

            return new ServiceResult<Dobavljac>(true, "Dobavljac uspesno izbrisan.");
        }
    }
}
