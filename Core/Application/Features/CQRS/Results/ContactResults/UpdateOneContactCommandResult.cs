namespace Application.Features.CQRS.Results.ContactResults
{
	public class UpdateOneContactCommandResult
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public bool IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
