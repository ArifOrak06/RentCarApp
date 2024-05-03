using Application.Features.CQRS.Commands.ProvidedServicesCommands;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class ProvidedServiceProfile : Profile
	{
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedService,GetOneProvidedServiceByIdQueryResult>().ReverseMap();
            CreateMap<ProvidedService,GetAllProvidedServicesQueryResult>().ReverseMap();
            CreateMap<ProvidedService,CreateOneProvidedServiceCommand>().ReverseMap();
            CreateMap<ProvidedService,CreateOneProvidedServiceCommandResult>().ReverseMap();
            CreateMap<ProvidedService,UpdateOneProvidedServiceCommandResult>().ReverseMap();
            CreateMap<ProvidedService,UpdateOneProvidedServiceCommand>().ReverseMap();
        }
    }
}
