namespace Application.Features.CQRS.Results.CarDescriptionResults
{
	public class CreateOneCarDescriptionCommandResult
	{
        public int Id { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
    }
}
