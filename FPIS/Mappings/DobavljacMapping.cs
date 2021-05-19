using FPIS.Domain;
using FPIS.Models;

namespace FPIS.Mappings
{
    public class DobavljacMapping : AutoMapper.Profile
    {
        public DobavljacMapping()
        {
            CreateMap<Dobavljac, DobavljacDto>().ReverseMap();

            CreateMap<Dobavljac, EditUlaznaFakturaDto>().ReverseMap();
        }
    }
}
