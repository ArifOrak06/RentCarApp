using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class SocialMediaCommandForManipulation
	{
		[Required(ErrorMessage = "Name alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(1, ErrorMessage = "Name alanı minimum 1 karakterden oluşturulmalıdır.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Url alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(3, ErrorMessage = "Url alanı minimum 3 karakterden oluşturulmalıdır.")]
		public string Url { get; set; }
		[Required(ErrorMessage = "Icon alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(3, ErrorMessage = "Icon alanı minimum 3 karakterden oluşturulmalıdır.")]
		public string Icon { get; set; }
	}
}
