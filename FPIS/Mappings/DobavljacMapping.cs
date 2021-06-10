using FPIS.Domain;
using FPIS.Models;
using FPIS.Service;

namespace FPIS.Mappings
{
    public class DobavljacMapping : AutoMapper.Profile
    {
        public DobavljacMapping()
        {
            CreateMap<Dobavljac, DobavljacDto>().ReverseMap();
            CreateMap<ServiceResult<Dobavljac>, ServiceResult<DobavljacDto>>().ReverseMap();

            CreateMap<Dobavljac, EditDobavljacDto>().ReverseMap();
            CreateMap<ServiceResult<Dobavljac>, ServiceResult<EditDobavljacDto>>().ReverseMap();

        }
    }
}
