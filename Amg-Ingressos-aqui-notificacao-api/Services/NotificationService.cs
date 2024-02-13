using Amg_Ingressos_aqui_notificacao_api.Consts;
using Amg_Ingressos_aqui_notificacao_api.Model;
using Amg_Ingressos_aqui_notificacao_api.Repository.Interfaces;
using Amg_Ingressos_aqui_notificacao_api.Services.Interfaces;

namespace Amg_Ingressos_aqui_notificacao_api.Services
{
    public class NotificationService : INotificationService
    {
        private readonly MessageReturn _messageReturn;
        private readonly ILogger<NotificationService> _logger;
        private readonly ICrudRepository<Notification> _crudRepository;


        public NotificationService(
            ILogger<NotificationService> logger,
            ICrudRepository<Notification> crudRepository)
        {
            _logger = logger;
            _messageReturn = new MessageReturn();
            _crudRepository = crudRepository;
        }

        public async Task<MessageReturn> Save(Notification notification)
        {
            try
            {
                notification.Validate();
                var dataUser = await _crudRepository.Save(notification);
                _messageReturn.Data = dataUser;
                return _messageReturn;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Format(MessageLogErrors.Login, this.GetType().Name, nameof(Save)));
                throw;
            }
        }
    }
}