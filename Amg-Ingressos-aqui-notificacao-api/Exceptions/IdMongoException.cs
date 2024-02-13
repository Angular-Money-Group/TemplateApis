namespace Amg_Ingressos_aqui_notificacao_api.Exceptions
{
    public class IdMongoException : Exception
    {
        public IdMongoException()
        {
        }

        public IdMongoException(string message) : base(message)
        {
        }

        public IdMongoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}