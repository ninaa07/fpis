using FPIS.Domain;

namespace FPIS.Service.Interfaces
{
    public interface IStavkaUlazneFaktureService
    {
        ServiceResult<StavkaUlazneFakture> Add(StavkaUlazneFakture stavkaUlaznaFaktura);

        ServiceResult<StavkaUlazneFakture> Update(StavkaUlazneFakture stavkaUlaznaFaktura);

        ServiceResult<StavkaUlazneFakture> Delete(StavkaUlazneFakture stavkaUlaznaFaktura);
    }
}
