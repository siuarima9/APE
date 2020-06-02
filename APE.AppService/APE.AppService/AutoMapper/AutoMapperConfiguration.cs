using APE.Application.AutoMapper.DomainToViewModel;
using APE.Application.AutoMapper.ViewModelToDomain;
using AutoMapper;

namespace APE.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new ViewModelToDomainMapping());
                ps.AddProfile(new DomainToViewModelMapping());
            });
        }
    }
}
