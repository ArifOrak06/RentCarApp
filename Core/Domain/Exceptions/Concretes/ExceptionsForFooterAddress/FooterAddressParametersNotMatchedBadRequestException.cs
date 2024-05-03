using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForFooterAddress
{
	public sealed class FooterAddressParametersNotMatchedBadRequestException : BadRequestException
	{
		public FooterAddressParametersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak gönderilen Route.Id : {routeId} ile Request.Body üzerinden gönderilen Object.Id :{objectId} bilgisi eşleşmemektedir.")
		{
		}
	}
}
