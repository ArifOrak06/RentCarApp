using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForCar
{
	public class CarObjectNullBadRequestException : BadRequestException
	{
		public CarObjectNullBadRequestException() : base("Parametre olarak gönderilen car nesnesi null")
		{
		}
	}
}
