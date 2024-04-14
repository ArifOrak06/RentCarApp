namespace Application.UnitOfWork
{
	public interface IUnitOfWork: IAsyncDisposable
	{
		Task<int> CommitAsync();
		void Commit();
	}
}
