namespace ConverterAPI.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>>GetAll();
        Task<T> GetById(string id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(string id);
    }
  
}
