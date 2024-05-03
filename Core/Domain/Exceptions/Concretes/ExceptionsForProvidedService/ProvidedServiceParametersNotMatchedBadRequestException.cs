using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForProvidedService
{
	public class ProvidedServiceParametersNotMatchedBadRequestException : BadRequestException
	{
		public ProvidedServiceParametersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak gönderilen Route.Id : {routeId} ile Request.Body içerisinde gönderilen object.Id : {objectId} bilgileri eşleşmemektedir.")
		{
		}
	}
}
