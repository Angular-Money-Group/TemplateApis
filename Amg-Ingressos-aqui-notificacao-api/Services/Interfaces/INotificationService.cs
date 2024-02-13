using Amg_Ingressos_aqui_notificacao_api.Model;

namespace Amg_Ingressos_aqui_notificacao_api.Services.Interfaces
{
    public interface INotificationService
    {
        Task<MessageReturn> Save(Notification notification);
    }
}