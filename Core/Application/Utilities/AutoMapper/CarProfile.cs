using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class CarProfile : Profile
	{
        public CarProfile()
        {
            CreateMap<Car, GetOneCarWithBrandByIdQueryResult>().ReverseMap();
            CreateMap<Car, GetAllCarsWithBrandsQueryResult>().ReverseMap();
            CreateMap<Car, CreateOneCarCommandResult>().ReverseMap();
            CreateMap<Car, CreateOneCarCommand>().ReverseMap();
            CreateMap<Car, UpdateOneCarCommandResult>().ReverseMap();
            CreateMap<Car, UpdateOneCarCommand>().ReverseMap();

        }
    }
}
