namespace Application.Features.CQRS.Results.LocationResults
{
	public class UpdateOneLocationCommandResult 
	{
        public int Id { get; set; }
		public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
