using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForProvidedService
{
	public sealed class ProvidedServiceNotFoundException : NotFoundException
	{
		public ProvidedServiceNotFoundException(int id) : base($"Provided Service with Id : {id} couldn't found.")
		{
		}
	}
}
