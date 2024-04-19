using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionForBrand
{
	public class BrandParametersNotMatchedBadRequestException : BadRequestException
	{
		public BrandParametersNotMatchedBadRequestException(int routeId,int brandId) : base($"Parametre olarak route ile gönderilen Id: {routeId} ile request.Body kısmında gönderilen Object.Id : {brandId} eşleşmemektedir.")
		{
		}
	}
}
