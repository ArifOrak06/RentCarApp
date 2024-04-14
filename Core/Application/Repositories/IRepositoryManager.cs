namespace Application.Repositories
{
	public interface IRepositoryManager 
	{
		IBannerRepository BannerRepository { get; }
		IAboutRepository AboutRepository { get; }
		ICarRepository CarRepository { get; }
		IBrandRepository BrandRepository { get; }
		ICarDescriptionRepository CarDescriptionRepository { get; }
		ICarFeatureRepository CarFeatureRepository { get; }
		ICarPricingRepository CarPricingRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		IContactRepository ContactRepository { get; }
		IFeatureRepository	FeatureRepository { get; }
		ILocationRepository LocationRepository { get; }
		IFooterAddressRepository FooterAddressRepository { get; }
		IPricingRepository PricingRepository { get; }
		IProvidedServiceRepository ProvidedServiceRepository { get; }
		ITestimonialRepository TestimonialRepository { get; }
		ISocialMediaRepository SocialMediaRepository { get; }
	}
}
