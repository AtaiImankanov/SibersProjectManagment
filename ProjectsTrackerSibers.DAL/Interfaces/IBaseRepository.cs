namespace ProjectsTrackerSibers.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create (T entity);
        Task<T> Get (Guid id);
        Task<IEnumerable<T>> Select();
        Task<bool> Delete (T entity);
    }
}
