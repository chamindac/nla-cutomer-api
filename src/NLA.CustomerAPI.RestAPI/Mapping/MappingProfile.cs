using AutoMapper;

namespace NLA.CustomerAPI.RestApi.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region     D O M A I N   T O   C O N T R A C T S 
            CreateMap<Domains.Customer, Contracts.Customer>()
              .ReverseMap();
            #endregion
        }
    }
}