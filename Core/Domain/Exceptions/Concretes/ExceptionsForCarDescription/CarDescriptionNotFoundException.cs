using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForCarDescription
{
	public class CarDescriptionNotFoundException : NotFoundException
	{
		public CarDescriptionNotFoundException(int id) : base($"CarDescription with Id : {id} couldn't found.")
		{
		}
	}
}
