namespace Mitarbeitershop_Hydro.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdIternalAsync(string id);
        Task AddIternalAsync(T entity);
        Task UpdateIternalAsync(T entity);
        Task DeleteIternalAsync(string id);
        IQueryable<T> QueryIternal();
    }
}
