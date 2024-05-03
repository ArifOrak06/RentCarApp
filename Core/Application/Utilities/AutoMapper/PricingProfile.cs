using Application.Features.CQRS.Handlers.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class PricingProfile : Profile
	{
        public PricingProfile()
        {
            CreateMap<Pricing, GetOnePricingWithCarPricingsByIdQueryResult>().ReverseMap();
            CreateMap<Pricing, GetAllPricingsWithCarPricingsQueryResult>().ReverseMap();
            CreateMap<Pricing, CreateOnePricingCommand>().ReverseMap();
            CreateMap<Pricing, CreateOnePricingCommandResult>().ReverseMap();
            CreateMap<Pricing, UpdateOnePricingCommand>().ReverseMap();
            CreateMap<Pricing, UpdateOnePricingCommandResult>().ReverseMap();
        }
    }
}
