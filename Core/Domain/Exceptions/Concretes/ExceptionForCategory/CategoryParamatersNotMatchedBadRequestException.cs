using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionForCategory
{
	public class CategoryParamatersNotMatchedBadRequestException : BadRequestException
	{
		public CategoryParamatersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak route üzerinden gönderilen Id : {routeId} ile Request Body içerisinde gönderilen object.Id : {objectId} eşleşmemektedir.")
		{
		}
	}
}
