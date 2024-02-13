namespace Amg_Ingressos_aqui_notificacao_api.Infra
{
    public class NotificationDatabaseSettings
    {
        /// <summary>
        /// Connection string base de dados Mongo
        /// </summary>
        public string ConnectionString { get; set; } = null!;
        /// <summary>
        /// Nome base de dados Mongo
        /// </summary>
        public string DatabaseName { get; set; } = null!;
        /// <summary>
        /// Nome collection Mongo
        /// </summary>
        public string EventCollectionName { get; set; } = null!;
    }
}