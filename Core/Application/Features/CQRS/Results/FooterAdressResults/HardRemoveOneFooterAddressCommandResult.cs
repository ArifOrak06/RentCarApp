namespace Application.Features.CQRS.Results.FooterAdressResults
{
	public class HardRemoveOneFooterAddressCommandResult
	{
        public int Id { get; set; }

		public HardRemoveOneFooterAddressCommandResult(int id)
		{
			Id = id;
		}
	}
}
