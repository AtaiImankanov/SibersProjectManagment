namespace ProjectsTrackerSibers.DAL.Interfaces
{
    public interface IBaseRepository <T>
    {

        Task<bool> Create (T entity);
        IQueryable<T> GetAll();
        Task<T> Get(Guid id);
        Task<bool> Delete (T entity);
        Task<bool> Edit (T entity);
    }
}
