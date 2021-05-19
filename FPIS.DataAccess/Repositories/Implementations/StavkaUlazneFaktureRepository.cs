using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;

namespace FPIS.DataAccess.Repositories.Implementations
{
    public class StavkaUlazneFaktureRepository : GenericRepository<StavkaUlazneFakture>, IStavkaUlazneFaktureRepository
    {
        public StavkaUlazneFaktureRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
