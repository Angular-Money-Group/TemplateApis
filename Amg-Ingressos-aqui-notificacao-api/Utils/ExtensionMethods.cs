using Amg_Ingressos_aqui_notificacao_api.Exceptions;

namespace Amg_Ingressos_aqui_notificacao_api.Utils
{
    public static class ExtensionMethods
    {
        public static void ValidateIdMongo(this string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new IdMongoException("Id é obrigatório");
            else if (id.Length < 24)
                throw new IdMongoException("Id é obrigatório e está menor que 24 digitos");
        }
    }
}