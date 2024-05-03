using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForSocialMedia
{
	public class SocialMediaParametersNotMatchedBadRequestException : BadRequestException
	{
		public SocialMediaParametersNotMatchedBadRequestException(int routeId, int objectId) : base($"Parametre olarak gönderilen Route.Id : {routeId} ile Request.Body içerisinde gönderilen Object.Id : {objectId} bilgileri eşleşmemektedir.")
		{
		}
	}
}
