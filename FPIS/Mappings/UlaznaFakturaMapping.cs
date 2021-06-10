using FPIS.Domain;
using FPIS.Models;
using FPIS.Service;

namespace FPIS.Mappings
{
    public class UlaznaFakturaMapping : AutoMapper.Profile
    {
        public UlaznaFakturaMapping()
        {
            CreateMap<UlaznaFaktura, UlaznaFakturaDto>().ReverseMap();
            CreateMap<ServiceResult<UlaznaFaktura>, ServiceResult<UlaznaFakturaDto>>().ReverseMap();

            CreateMap<UlaznaFaktura, EditUlaznaFakturaDto>().ReverseMap();
            CreateMap<ServiceResult<UlaznaFaktura>, ServiceResult<EditUlaznaFakturaDto>>().ReverseMap();

            CreateMap<StavkaUlazneFakture, StavkaUlazneFaktureDto>().ReverseMap();
        }
    }
}
