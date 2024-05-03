namespace Application.Features.CQRS.Results.FooterAdressResults
{
	public class GetAllFooterAddressQueryResult
	{
        public int Id { get; set; }
        public string Description { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
