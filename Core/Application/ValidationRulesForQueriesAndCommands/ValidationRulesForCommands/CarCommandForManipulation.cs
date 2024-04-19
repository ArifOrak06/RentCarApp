using System.ComponentModel.DataAnnotations;

namespace Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands
{
	public abstract class CarCommandForManipulation
	{
		[Required(ErrorMessage = "BrandId bilgi girilmesi zorunlu bir alandır.")]
		public int BrandId { get; set; }
		[Required(ErrorMessage = "Model alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "Model alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string Model { get; set; }
		[Required(ErrorMessage = "CoverImageUrl alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(2, ErrorMessage = "CoverImageUrl alanı minimum 2 karakterden oluşturulmalıdır.")]
		public string CoverImageUrl { get; set; }
		[Required(ErrorMessage = "Km alanı bilgi girilmesi zorunlu bir alandır.")]
		[Range(1, 300000, ErrorMessage = "Km alanına giriş yapılacak değer 1 ile 300.000 aralığında olmalıdır.")]
		public int Km { get; set; }
		[Required(ErrorMessage = "Transmission alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(3, ErrorMessage = "Transmission alanı minimum 3 karakterden oluşturulmalıdır.")]
		public string Transmission { get; set; }
		[Required(ErrorMessage = "Luggage alanı bilgi girilmesi zorunlu bir alandır.")]
		[Range(1, 1000, ErrorMessage = "Luggage alanına giriş yapılacak değer 1 ile 1000 aralığında olmalıdır.")]
		public int Luggage { get; set; }
		[Required(ErrorMessage = "Luggage alanı bilgi girilmesi zorunlu bir alandır.")]
		[Range(1, 300000, ErrorMessage = "Luggage alanına giriş yapılacak değer 1 ile 1000 aralığında olmalıdır.")]
		public int Kilometers { get; set; }
		[Required(ErrorMessage = "Seat alanı bilgi girilmesi zorunlu bir alandır.")]
		[Range(1, 1000, ErrorMessage = "Seat alanına giriş yapılacak değer 1 ile 1000 aralığında olmalıdır.")]
		public int Seat { get; set; }
		[Required(ErrorMessage = "Fuel alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(3, ErrorMessage = "Fuel alanı minimum 3 karakterden oluşturulmalıdır.")]
		public string Fuel { get; set; }
		[Required(ErrorMessage = "BigImageUrl alanı bilgi girilmesi zorunlu bir alandır.")]
		[MinLength(3, ErrorMessage = "BigImageUrl alanı minimum 3 karakterden oluşturulmalıdır.")]
		public string BigImageUrl { get; set; }
	}
}
