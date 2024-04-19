using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionForBrand
{
	public class BrandObjectNullBadRequestException : BadRequestException
	{
		public BrandObjectNullBadRequestException() : base($"Parametre olarak gönderilen object null")
		{
		}
	}
}
