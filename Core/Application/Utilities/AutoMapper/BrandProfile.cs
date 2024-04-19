using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class BrandProfile : Profile
	{
        public BrandProfile()
        {
            CreateMap<Brand,GetAllBrandsWithCarsQueryResult>().ReverseMap();
            CreateMap<Brand, GetOneBrandWithCarsQueryResult>().ReverseMap();
            CreateMap<Brand, CreateOneBrandCommand>().ReverseMap();
            CreateMap<Brand, CreateOneBrandCommandResult>().ReverseMap();
            CreateMap<Brand, UpdateOneBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateOneBrandCommandResult>().ReverseMap();

        }
    }
}
