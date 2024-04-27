using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class ContactCommandForManipulation
	{
		[Required(ErrorMessage = "Name alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Name alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Email alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(5, ErrorMessage = "Email alanı minimum 5 karakterden oluşturulmalıdır.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Subject alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Subject alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Subject { get; set; }
		[Required(ErrorMessage = "Message alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(3, ErrorMessage = "Message alanı minimum 3 karakterden oluşturulmalıdır.")]
		public string Message { get; set; }
	}
}
