using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class BannerCommandForManipulation
	{
		[Required(ErrorMessage = "Title zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Title alanı en az 2 karakterden oluşmalıdır.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Description alanı en az 2 karakterden oluşmalıdır.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "VideoDescription zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "VideoDescription alanı en az 2 karakterden oluşmalıdır.")]
		public string VideoDescription { get; set; }

		[Required(ErrorMessage = "VideoUrl zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "VideoUrl alanı en az 2 karakterden oluşmalıdır.")]
		public string VideoUrl { get; set; }
	}
}
