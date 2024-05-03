using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionsForSocialMedia
{
	public class SocialMediaNotFoundException : NotFoundException
	{
		public SocialMediaNotFoundException(int id) : base($"Social Media with Id : {id} couldn't found.")
		{
		}
	}
}
