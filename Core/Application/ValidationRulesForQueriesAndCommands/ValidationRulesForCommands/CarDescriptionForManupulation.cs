using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class CarDescriptionForManupulation
	{
        [Required(ErrorMessage="Description alanı bilgi girilmesi zorunlu bir alandır.")]
        public string Description { get; set; }
		[Required(ErrorMessage = "CarId alanı bilgi girilmesi zorunlu bir alandır.")]
		public int CarId { get; set; }
    }
}
