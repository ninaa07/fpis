using FPIS.Domain;
using FPIS.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace FPIS.Service.Implementations
{
    public class UlaznaFakturaService: IUlaznaFakturaService
    {
        private readonly IUlaznaFakturaService _ulaznaFakturaService;
        public UlaznaFakturaService(IUlaznaFakturaService ulaznaFakturaService)
        {
            _ulaznaFakturaService = ulaznaFakturaService;
        }

        public UlaznaFaktura Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UlaznaFaktura> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<UlaznaFaktura> Add(UlaznaFaktura ulaznaFaktura)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<UlaznaFaktura> Update(UlaznaFaktura ulaznaFaktura)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<UlaznaFaktura> Delete(UlaznaFaktura ulaznaFaktura)
        {
            throw new NotImplementedException();
        }
    }
}
