using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace CompanyEmplayees;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAdress,
                opt =>
                    opt.MapFrom(x => string.Join(" ", x.Address, x.Country)));
    }
}