using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class CategoryForManipulation
	{
		[Required(ErrorMessage = "Description alanı bilgi birilmesi zorunlu bir alandır.")]
		public string Name { get; set; }
	}
}
