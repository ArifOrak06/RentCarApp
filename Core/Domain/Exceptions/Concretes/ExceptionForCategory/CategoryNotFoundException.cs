using Domain.Exceptions.Abstracts;

namespace Domain.Exceptions.Concretes.ExceptionForCategory
{
	public class CategoryNotFoundException : NotFoundException
	{
		public CategoryNotFoundException(int id) : base($"Category with Id : {id} could'nt found.")
		{
		}
	}
}
