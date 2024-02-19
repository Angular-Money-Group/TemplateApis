using Amg_Ingressos_aqui_notificacao_api.Infra.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Amg_Ingressos_aqui_notificacao_api.Infra
{
    public class DbConnection : IDbConnection
    {
        private readonly IOptions<NotificationDatabaseSettings> _config;
        private MongoClient _mongoClient;
        public DbConnection(IOptions<NotificationDatabaseSettings> authDatabaseSettings)
        {
            _mongoClient = new MongoClient();
            _config = authDatabaseSettings;
        }

        public IMongoCollection<T> GetConnection<T>()
        {
            
            var colletionName = GetCollectionName<T>();
            Console.WriteLine(Environment.GetEnvironmentVariable("MONGOURL")?? "está nullllllllllllllllllll");
            _mongoClient = new MongoClient(new MongoUrl(Environment.GetEnvironmentVariable("MONGOURL")));
            var mongoDatabase = _mongoClient.GetDatabase(_config.Value.DatabaseName);

            return mongoDatabase.GetCollection<T>(colletionName);
        }

        public MongoClient GetClient()
        {
            return _mongoClient;
        }
        private static string GetCollectionName<T>()
        {

            return typeof(T).Name.ToLower() ?? string.Empty;
        }
    }
}