namespace Domain.Entities.RequestFeatures
{
	public abstract class RequestParameters
	{
		const int MaxPageSize = 50;
        public int PageNumber { get; set; }
		public int _pageSize;
        public int PageSize 
		{ 
			get { return _pageSize; }
			set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
		}



    }
}
