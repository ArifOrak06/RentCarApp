using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForContact
{
	public class ContactParametersNotMatchedBadRequestException : BadRequestException
	{
		public ContactParametersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak gönderilen Route.Id : {routeId} ile Request.Body içerisinde gönderilen Object.Id : {objectId} eşleşmemektedir.")
		{
		}
	}
}
