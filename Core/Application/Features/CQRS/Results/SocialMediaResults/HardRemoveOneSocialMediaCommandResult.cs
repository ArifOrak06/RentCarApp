namespace Application.Features.CQRS.Results.SocialMediaResults
{
	public class HardRemoveOneSocialMediaCommandResult
	{
        public int Id { get; set; }

		public HardRemoveOneSocialMediaCommandResult(int id)
		{
			Id = id;
		}
	}
}
