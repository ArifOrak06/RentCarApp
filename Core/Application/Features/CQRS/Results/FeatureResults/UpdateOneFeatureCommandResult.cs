using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.FeatureResults
{
	public class UpdateOneFeatureCommandResult
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
