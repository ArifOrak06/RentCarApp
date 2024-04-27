namespace Application.Features.CQRS.Results.CarDescriptionResults
{
	public class UpdateOneCarDescriptionCommandResult
	{
        public int Id { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
