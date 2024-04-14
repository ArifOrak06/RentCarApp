using Application.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly AppDbContext _context;
		private readonly Lazy<IBannerRepository> _bannerRepository;
		private readonly Lazy<IAboutRepository> _aboutRepository;
		private readonly Lazy<ICarRepository> _carRepository;
		private readonly Lazy<IBrandRepository> _brandRepository;
		private readonly Lazy<ICarDescriptionRepository> _carDescriptionRepository;
		private readonly Lazy<ICarFeatureRepository> _carFeatureRepository;
		private readonly Lazy<ICarPricingRepository> _carPricingRepository;
		private readonly Lazy<ICategoryRepository> _categoryRepository;
		private readonly Lazy<IContactRepository> _contactRepository;
		private readonly Lazy<IFeatureRepository> _featureRepository;
		private readonly Lazy<ILocationRepository> _locationRepository;
		private readonly Lazy<IFooterAddressRepository> _footerAddressRepository;
		private readonly Lazy<IPricingRepository> _pricingRepository;
		private readonly Lazy<IProvidedServiceRepository> _providedServiceRepository;
		private readonly Lazy<ITestimonialRepository> _testimonialRepository;
		private readonly Lazy<ISocialMediaRepository> _socialMediaRepository;
		public RepositoryManager(AppDbContext context)
		{
			_context = context;
			_bannerRepository = new Lazy<IBannerRepository>(() => new BannerRepository(_context));
			_aboutRepository = new Lazy<IAboutRepository>(() => new AboutRepository(_context));
			_carRepository = new Lazy<ICarRepository>(() => new CarRepository(_context));
			_brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(_context));
			_carDescriptionRepository = new Lazy<ICarDescriptionRepository>(() => new CarDescriptionRepository(_context));
			_carFeatureRepository = new Lazy<ICarFeatureRepository>(() => new CarFeatureRepository(_context));
			_carPricingRepository = new Lazy<ICarPricingRepository>(() => new CarPricingRepository(_context));
			_categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
			_contactRepository = new Lazy<IContactRepository>(()=> new ContactRepository(_context));
			_featureRepository = new Lazy<IFeatureRepository>(() => new FeatureRepository(_context));
			_locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(_context));
			_footerAddressRepository = new Lazy<IFooterAddressRepository>(() => new FooterAddressRepository(_context));
			_pricingRepository = new Lazy<IPricingRepository>(() => new PricingRepository(_context));
			_providedServiceRepository = new Lazy<IProvidedServiceRepository>(()=> new ProvidedServiceRepository(_context));
			_testimonialRepository = new Lazy<ITestimonialRepository>(() => new TestimonialRepository(_context));
			_socialMediaRepository = new Lazy<ISocialMediaRepository>(() => new SocialMediaRepository(_context));


		}

	
		public IBannerRepository BannerRepository => _bannerRepository.Value;

		public IAboutRepository AboutRepository => _aboutRepository.Value;

		public ICarRepository CarRepository => _carRepository.Value;

		public IBrandRepository BrandRepository => _brandRepository.Value;

		public ICarDescriptionRepository CarDescriptionRepository => _carDescriptionRepository.Value;

		public ICarFeatureRepository CarFeatureRepository => _carFeatureRepository.Value;

		public ICarPricingRepository CarPricingRepository => _carPricingRepository.Value;

		public ICategoryRepository CategoryRepository => _categoryRepository.Value;

		public IContactRepository ContactRepository => _contactRepository.Value;

		public IFeatureRepository FeatureRepository => _featureRepository.Value;

		public ILocationRepository LocationRepository => _locationRepository.Value;
		public IFooterAddressRepository FooterAddressRepository => _footerAddressRepository.Value;

		public IPricingRepository PricingRepository => _pricingRepository.Value;

		public IProvidedServiceRepository ProvidedServiceRepository => _providedServiceRepository.Value;

		public ITestimonialRepository TestimonialRepository => _testimonialRepository.Value;

		public ISocialMediaRepository SocialMediaRepository => _socialMediaRepository.Value;
	}
}
