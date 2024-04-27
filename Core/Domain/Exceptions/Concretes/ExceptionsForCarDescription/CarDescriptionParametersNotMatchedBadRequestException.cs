using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForCarDescription
{
	public class CarDescriptionParametersNotMatchedBadRequestException : BadRequestException
	{
		public CarDescriptionParametersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak gönderilen route Id : {routeId} ile Request.Body içerisinde gönderilen object.Id : {objectId} bilgileri eşleşmemektedir.")
		{
		}
	}
}
