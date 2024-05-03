using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Queries.FooterAddressQueries;
using Application.Features.CQRS.Results.FooterAdressResults;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Utilities.AutoMapper
{
	public class FooterAddressProfile : Profile
	{
        public FooterAddressProfile()
        {
            CreateMap<FooterAddress, GetAllFooterAddressQueryResult>().ReverseMap();
            CreateMap<FooterAddress, GetOneFooterAddressByIdQueryResult>().ReverseMap();
            CreateMap<FooterAddress, CreateOneFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddress, CreateOneFooterAddressCommandResult>().ReverseMap();
            CreateMap<FooterAddress, UpdateOneFooterAddressCommand>().ReverseMap();
            CreateMap<FooterAddress, UpdateOneFooterAddressCommandResult>().ReverseMap();
        }
    }
}
