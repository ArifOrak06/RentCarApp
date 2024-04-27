using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.FeatureResults
{
	public class CreateOneFeatureCommandResult
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
