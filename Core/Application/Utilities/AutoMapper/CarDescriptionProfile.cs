using Application.Features.CQRS.Commands.CarDescriptionCommands;
using Application.Features.CQRS.Results.CarDescriptionResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class CarDescriptionProfile : Profile
	{
        public CarDescriptionProfile()
        {
            CreateMap<CarDescription,GetAllCarDescriptionsWithCarsQueryResult>().ReverseMap();
            CreateMap<CarDescription,GetOneCarDescriptionWithCarByIdQueryResult>().ReverseMap();
            CreateMap<CarDescription,CreateOneCarDescriptionCommand>().ReverseMap();
            CreateMap<CarDescription,CreateOneCarDescriptionCommandResult>().ReverseMap();
            CreateMap<CarDescription,UpdateOneCarDescriptionCommand>().ReverseMap();
            CreateMap<CarDescription,UpdateOneCarDescriptionCommandResult>().ReverseMap();
        }
    }
}
