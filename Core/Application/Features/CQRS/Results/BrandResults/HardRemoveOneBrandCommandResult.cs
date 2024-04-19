namespace Application.Features.CQRS.Results.BrandResults
{
	public class HardRemoveOneBrandCommandResult
	{
        public int Id { get; set; }

		public HardRemoveOneBrandCommandResult(int id)
		{
			Id = id;
		}
	}
}
