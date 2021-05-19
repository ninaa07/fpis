using FPIS.Domain;
using FPIS.Models;

namespace FPIS.Mappings
{
    public class UlaznaFakturaMapping : AutoMapper.Profile
    {
        public UlaznaFakturaMapping()
        {
            CreateMap<UlaznaFaktura, UlaznaFakturaDto>().ReverseMap();

            CreateMap<UlaznaFaktura, EditUlaznaFakturaDto>().ReverseMap();

            CreateMap<StavkaUlazneFakture, StavkaUlazneFaktureDto>().ReverseMap();
        }
    }
}
