using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class TestimonialRepository : RepositoryBase<Testimonial>, ITestimonialRepository
	{
		public TestimonialRepository(AppDbContext context) : base(context)
		{
		}
	}
}
