using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForLocation
{
	public sealed class LocationParametersNotMatchedBadRequestException : BadRequestException
	{
		public LocationParametersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak Route'dan gönderilen Route.Id : {routeId} ile Request.Body üzerinden gönderilen object.Id : {objectId} bilgileri eşleşmemektedir.")
		{
		}
	}
}
