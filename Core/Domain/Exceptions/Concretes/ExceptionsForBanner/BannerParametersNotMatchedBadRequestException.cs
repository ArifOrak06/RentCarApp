using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForBanner
{
	public sealed class BannerParametersNotMatchedBadRequestException : BadRequestException
	{
		public BannerParametersNotMatchedBadRequestException(int id,int routeId) : base($"Parametre olarak gönderilen object.Id : {id} ile route'dan gönderilen {routeId} değerleri eşleşmemektedir.")
		{
		}
	}
}
