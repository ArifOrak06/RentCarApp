using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForCar
{
	public class CarParametersNotMatchedBadRequestException : BadRequestException
	{
		public CarParametersNotMatchedBadRequestException(int carId,int routeId) : base($"Parametre olarak gönderilen object.Id : {carId} ile route üzerinden gönderilen Id: {routeId} eşleşmemektedir.")
		{
		}
	}
}
