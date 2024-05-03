using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class LocationProfile : Profile
	{
        public LocationProfile()
        {
            CreateMap<Location, GetAllLocationsQueryResult>().ReverseMap();
            CreateMap<Location, CreateOneLocationCommand>().ReverseMap();
            CreateMap<Location, CreateOneLocationCommandResult>().ReverseMap();
            CreateMap<Location, UpdateOneLocationCommand>().ReverseMap();
            CreateMap<Location, UpdateOneLocationCommandResult>().ReverseMap();
        }
    }
}
