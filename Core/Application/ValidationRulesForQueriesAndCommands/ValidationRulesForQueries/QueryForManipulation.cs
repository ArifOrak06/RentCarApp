using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForQueries
{
	public abstract class QueryForManipulation
	{
        [Required(ErrorMessage = "Id alanı zorunlu bir alandır.")]
        public int Id { get; set; }
        protected QueryForManipulation(int id) { Id = id; }

    }
}
