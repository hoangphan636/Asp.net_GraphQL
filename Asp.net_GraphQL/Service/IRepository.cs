namespace Asp.net_GraphQL.Service
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
         Task<T> GetByIdAsync(int? id);
        void InsertAsync(T obj);
        void UpdateAsync(T obj);
        void DeleteAsync(int id);
        
    }
}
