using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class LocationCommandForManipulation
	{
		[Required(ErrorMessage = "Name alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Name alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Name { get; set; }
	}
}
