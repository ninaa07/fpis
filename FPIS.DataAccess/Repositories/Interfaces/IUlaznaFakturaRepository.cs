using FPIS.Domain;
using System.Collections.Generic;

namespace FPIS.DataAccess.Repositories.Interfaces
{
    public interface IUlaznaFakturaRepository : IGenericRepository<UlaznaFaktura>
    {
        IEnumerable<UlaznaFaktura> Search(string searchTerm, int status);

        IEnumerable<UlaznaFaktura> GetAllUfWithStavke();

        IEnumerable<Proizvod> GetAllProizvodi();

        IEnumerable<PackingLista> GetAllPackingListe();
    }
}
