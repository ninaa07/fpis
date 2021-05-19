using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using FPIS.Service.Interfaces;
using System;

namespace FPIS.Service.Implementations
{
    public class StavkaUlazneFaktureService : IStavkaUlazneFaktureService
    {
        private readonly IStavkaUlazneFaktureRepository _stavkaUlazneFaktureRepository;

        public StavkaUlazneFaktureService(IStavkaUlazneFaktureRepository stavkaUlazneFaktureRepository)
        {
            _stavkaUlazneFaktureRepository = stavkaUlazneFaktureRepository;
        }

        public ServiceResult<StavkaUlazneFakture> Add(StavkaUlazneFakture stavkaUlaznaFakture)
        {
            _stavkaUlazneFaktureRepository.Add(stavkaUlaznaFakture);

            _stavkaUlazneFaktureRepository.SaveChanges();

            return new ServiceResult<StavkaUlazneFakture>(true, "Stavka ulazne fakture je uspesno dodata.", stavkaUlaznaFakture);
        }

        public ServiceResult<StavkaUlazneFakture> Update(StavkaUlazneFakture stavkaUlaznaFakture)
        {
            _stavkaUlazneFaktureRepository.Update(stavkaUlaznaFakture);

            _stavkaUlazneFaktureRepository.SaveChanges();

            return new ServiceResult<StavkaUlazneFakture>(true, "Stavka ulazne fakture uspesno izmenjen.", stavkaUlaznaFakture);
        }

        public ServiceResult<StavkaUlazneFakture> Delete(StavkaUlazneFakture stavkaUlaznaFakture)
        {
            _stavkaUlazneFaktureRepository.Delete(stavkaUlaznaFakture);

            _stavkaUlazneFaktureRepository.SaveChanges();

            return new ServiceResult<StavkaUlazneFakture>(true, "Stavka ulazne fakture uspesno izbrisan.");
        }
    }
}
