namespace Application.Features.CQRS.Results.BannerResults
{
	public class SoftRemoveOneBannerCommandResult
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
