namespace Application.Features.CQRS.Results.ProvidedServiceResults
{
	public class HardRemoveOneProvidedServiceCommandResult 
	{
        public int Id { get; set; }

		public HardRemoveOneProvidedServiceCommandResult(int id)
		{
			Id = id;
		}
	}
}
