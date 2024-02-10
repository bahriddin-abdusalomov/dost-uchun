namespace DemoProject.Interfaces
{
    public interface IBaseRepository<TModel>
    {
        Task<int> CreateAsync(TModel model);
        Task<IList<TModel>> GetAllAsync();
        Task<TModel> GetAsync(long id);
        Task<int> UpdateAsync(TModel model);
        Task<int> DeleteAsync(TModel model);
    }
}
