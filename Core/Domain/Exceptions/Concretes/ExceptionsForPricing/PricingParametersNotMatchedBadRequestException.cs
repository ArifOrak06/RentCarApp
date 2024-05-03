using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForPricing
{
	public sealed class PricingParametersNotMatchedBadRequestException : BadRequestException
	{
		public PricingParametersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak gönderilen Route.Id : {routeId} ile Request.Body'de gönderilen Object.ID : {objectId} bilgileri eşleşmemektedir.")
		{
		}
	}
}
