using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForFeature
{
	public class FeatureParametersNotMatchedBadRequestException : BadRequestException
	{
		public FeatureParametersNotMatchedBadRequestException(int routeId,int objectId) : base($"Parametre olarak gönderilen route ıd {routeId} bilgisi ile Request.Body içerisinde gönderilen Object.Id : {objectId} eşleşmemektedir.")
		{
		}
	}
}
