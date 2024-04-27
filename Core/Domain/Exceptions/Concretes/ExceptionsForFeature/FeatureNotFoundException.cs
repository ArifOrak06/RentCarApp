using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForFeature
{
	public class FeatureNotFoundException : NotFoundException
	{
		public FeatureNotFoundException(int id) : base($"Feature with Id : {id} could'nt found.")
		{

		}

	}

}
