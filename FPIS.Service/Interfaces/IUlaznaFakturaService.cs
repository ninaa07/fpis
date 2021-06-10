using FPIS.Domain;
using System.Collections.Generic;

namespace FPIS.Service.Interfaces
{
    public interface IUlaznaFakturaService
    {
        IEnumerable<UlaznaFaktura> Search(string searchTerm, int status);

        IEnumerable<UlaznaFaktura> GetAll();

        UlaznaFaktura Get(int id);

        ServiceResult<UlaznaFaktura> Add(UlaznaFaktura ulaznaFaktura);

        ServiceResult<UlaznaFaktura> Update(UlaznaFaktura ulaznaFaktura);

        ServiceResult<UlaznaFaktura> Delete(UlaznaFaktura ulaznaFaktura);

        IEnumerable<Proizvod> GetAllProizvodi();

        IEnumerable<PackingLista> GetAllPackingListe();
    }
}
