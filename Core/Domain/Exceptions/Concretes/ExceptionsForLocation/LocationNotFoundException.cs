using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForLocation
{
	public sealed class LocationNotFoundException : NotFoundException
	{
		public LocationNotFoundException(int id) : base($"Location with Id : {id} could'nt found.")
		{
		}
	}
}
