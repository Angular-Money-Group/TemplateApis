using MongoDB.Driver;

namespace Amg_Ingressos_aqui_notificacao_api.Infra.Interfaces
{
    public interface IDbConnection
    {
        IMongoCollection<T> GetConnection<T>();
        MongoClient GetClient();
    }
}