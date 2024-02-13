using Amg_Ingressos_aqui_notificacao_api.Exceptions;
using Amg_Ingressos_aqui_notificacao_api.Model;
using Amg_Ingressos_aqui_notificacao_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Amg_Ingressos_aqui_notificacao_api.Controllers
{
    [Route("v1/Notification")]
    [Produces("application/json")]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationService _notificationService;

        public NotificationController(ILogger<NotificationController> logger, INotificationService authService)
        {
            _logger = logger;
            _notificationService = authService;
        }

        /// <summary>
        /// Busca os eventos
        /// </summary>
        /// <param name="filters"> filtros </param>
        /// <param name="paginationOptions"> paginacao </param>
        /// <returns>200 Lista de todos eventos</returns>
        /// <returns>204 Nenhum evento encontrado</returns>
        /// <returns>500 Erro inesperado</returns>
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Save()
        {
            /*if (!ModelState.IsValid)
                throw new RuleException("Dados sao necessários");

            var result = await _notificationService.Save(notification);
            
            if (result.Message != null && result.Message.Any())
            {
                _logger.LogInformation(result.Message);
                return StatusCode(500, result.Message);
            }
            if (result.Data.ToString() == string.Empty)
                return NoContent();
            

            return Ok(result.Data);
            */
            return Ok("Teste Publish");
        }
    }
}