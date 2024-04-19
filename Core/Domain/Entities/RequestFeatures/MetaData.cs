namespace Domain.Entities.RequestFeatures
{
	// ResponseHeaders'a eklenecek sayfalama künye bilgilerini içermektedir.
	public class MetaData
	{
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount{ get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPage;

    }
}
