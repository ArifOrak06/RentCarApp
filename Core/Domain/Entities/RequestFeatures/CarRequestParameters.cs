namespace Domain.Entities.RequestFeatures
{
	public abstract class CarRequestParameters : RequestParameters
	{
        protected CarRequestParameters(int pageNumber, int pageSize) 
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
