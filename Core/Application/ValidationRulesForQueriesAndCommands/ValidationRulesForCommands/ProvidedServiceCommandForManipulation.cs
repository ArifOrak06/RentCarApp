using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class ProvidedServiceCommandForManipulation
	{
		[Required(ErrorMessage = "title alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Title alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Title { get; set; }
		[Required(ErrorMessage = "Description alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Description alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Description { get; set; }
		[Required(ErrorMessage = "IconUrl alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "IconUrl alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string IconUrl { get; set; }
	}
}
