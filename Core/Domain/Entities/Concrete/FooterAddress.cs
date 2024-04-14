using Domain.Entities.Abstracts;

namespace Domain.Entities.Concrete
{
	public class FooterAddress : BaseEntity,IEntity
	{
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
    }
}
