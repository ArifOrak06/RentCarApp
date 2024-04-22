using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class CategoryProfile : Profile
	{
        public CategoryProfile()
        {
            CreateMap<Category, GetAllCategoriesQueryResult>().ReverseMap();
            CreateMap<Category, GetOneCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, CreateOneCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateOneCategoryCommandResult>().ReverseMap();
            CreateMap<Category, UpdateOneCategoryCommandResult>().ReverseMap();
            CreateMap<Category, UpdateOneCategoryCommand>().ReverseMap();

        }
    }
}
