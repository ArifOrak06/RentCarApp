using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class FeatureForManupulation
	{
		[Required(ErrorMessage =("Name alanı doldurulması zorunlu bir alandır."))]
        public string Name { get; set; }

    }
}
