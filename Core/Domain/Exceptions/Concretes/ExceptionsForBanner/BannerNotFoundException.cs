using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForBanner
{
	public sealed class BannerNotFoundException : NotFoundException
	{
		public BannerNotFoundException(int id) : base($"Banner with Id : {id} could not found.")
		{
		}
	}
}
