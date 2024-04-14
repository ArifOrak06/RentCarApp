namespace Application.Features.CQRS.Results.BannerResults
{
	public class UpdateOneBannerCommandResult
	{
        public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string VideoDescription { get; set; }
		public string VideoUrl { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
