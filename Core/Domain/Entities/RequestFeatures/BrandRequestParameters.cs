namespace Domain.Entities.RequestFeatures
{
	public abstract class BrandRequestParameters : RequestParameters
	{
        protected BrandRequestParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
