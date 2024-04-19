namespace Domain.Entities.RequestFeatures
{
	public class PagedList<T> : List<T>
	{
        public MetaData MetaData { get; set; }
        public PagedList(List<T> items, int entityCount, int pageNumber,int pageSize)
        {
            MetaData = new()
            {
                TotalCount = entityCount,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(entityCount / (double)pageSize)
            };
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
