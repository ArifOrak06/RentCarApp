using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForBanner
{
	public class BannerObjectNullBadRequestException : BadRequestException
	{
		public BannerObjectNullBadRequestException() : base("Parametre olarak gönderilen Object null")
		{
		}
	}
}
