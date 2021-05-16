using FPIS.DataAccess.Repositories.Interfaces;
using FPIS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPIS.DataAccess.Repositories.Implementations
{
    public class UlaznaFakturaRepository : GenericRepository<UlaznaFaktura>, IUlaznaFakturaRepository
    {
        public UlaznaFakturaRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
