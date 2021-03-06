using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using FPIS.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FPIS.Service.Implementations
{
    public class UlaznaFakturaService : IUlaznaFakturaService
    {
        private readonly IUlaznaFakturaRepository _ulaznaFakturaRepository;

        public UlaznaFakturaService(IUlaznaFakturaRepository ulaznaFakturaRepository)
        {
            _ulaznaFakturaRepository = ulaznaFakturaRepository;
        }

        public IEnumerable<UlaznaFaktura> GetAll()
        {
            return _ulaznaFakturaRepository.GetAllUfWithStavke();
        }

        public IEnumerable<Proizvod> GetAllProizvodi()
        {
            return _ulaznaFakturaRepository.GetAllProizvodi();
        }

        public IEnumerable<PackingLista> GetAllPackingListe()
        {
            return _ulaznaFakturaRepository.GetAllPackingListe();
        }

        public UlaznaFaktura Get(int id)
        {
            return _ulaznaFakturaRepository.GetAllUfWithStavke().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<UlaznaFaktura> Search(string searchTerm, int status)
        {
            return _ulaznaFakturaRepository.Search(searchTerm, status);
        }

        public ServiceResult<UlaznaFaktura> Add(UlaznaFaktura ulaznaFaktura)
        {
            _ulaznaFakturaRepository.Add(ulaznaFaktura);

            _ulaznaFakturaRepository.SaveChanges();

            return new ServiceResult<UlaznaFaktura>(true, "Ulazna faktura je uspesno dodata.", ulaznaFaktura);
        }

        public ServiceResult<UlaznaFaktura> Update(UlaznaFaktura ulaznaFaktura)
        {
            _ulaznaFakturaRepository.Update(ulaznaFaktura);

            _ulaznaFakturaRepository.SaveChanges();

            return new ServiceResult<UlaznaFaktura>(true, "Ulazna faktura uspesno izmenjen.", ulaznaFaktura);
        }

        public ServiceResult<UlaznaFaktura> Delete(UlaznaFaktura ulaznaFaktura)
        {
            _ulaznaFakturaRepository.Delete(ulaznaFaktura);

            _ulaznaFakturaRepository.SaveChanges();

            return new ServiceResult<UlaznaFaktura>(true, "Ulazna faktura uspesno izbrisan.", ulaznaFaktura);
        }
    }
}
