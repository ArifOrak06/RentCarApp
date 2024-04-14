using System.Text.Json;

namespace Domain.ErrorModels
{
	public class ErrorDetails
	{
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
