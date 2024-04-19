using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForCar
{
	public class CarNotFoundException : NotFoundException
	{
		public CarNotFoundException(int id) : base($"Car with id : {id} couldn't found.")
		{
		}
	}
}
