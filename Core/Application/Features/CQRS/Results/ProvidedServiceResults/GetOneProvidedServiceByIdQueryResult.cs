namespace Application.Features.CQRS.Results.ProvidedServiceResults
{
	public class GetOneProvidedServiceByIdQueryResult
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconUrl { get; set; }
	}
}
