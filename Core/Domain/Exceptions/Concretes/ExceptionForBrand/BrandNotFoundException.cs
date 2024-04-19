using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionForBrand
{
	public class BrandNotFoundException : NotFoundException
	{
		public BrandNotFoundException(int id) : base($"Brand with Id : {id} could not found.")
		{
		}
	}
}
