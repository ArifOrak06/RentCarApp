namespace Domain.Exceptions.Abstracts
{
	public abstract class BadRequestException : Exception
	{
        public BadRequestException(string message) : base(message)
        {
            
        }
    }
}
