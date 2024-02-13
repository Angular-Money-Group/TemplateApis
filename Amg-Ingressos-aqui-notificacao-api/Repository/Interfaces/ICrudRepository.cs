namespace Amg_Ingressos_aqui_notificacao_api.Repository.Interfaces
{
    public interface ICrudRepository<T>
    {
        Task<T> GetById(string id);
        Task<List<T>> GetAll();
        Task<List<T>> GetByFilter(Dictionary<string,object> filters);
        Task<T> Save(T model);
        Task<bool> Edit(string id, T model);
        Task<bool> Delete(string id);
    }
}