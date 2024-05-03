using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class FooterAddressCommandForManipulation
	{
		[Required(ErrorMessage = "Description alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Description alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Address alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Address alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Address { get; set; }
		[Required(ErrorMessage = "Phone alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(10, ErrorMessage = "Phone alanı minimum 10 karakterden oluşturulmalıdır.")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Email alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(5, ErrorMessage = "Email alanı minimum 5 karakterden oluşturulmalıdır.")]
		public string Email { get; set; }
	}
}
