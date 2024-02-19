using Microsoft.AspNetCore.Mvc;

namespace Amg_Ingressos_aqui_notificacao_api.Controllers
{
    [Route("[controller]")]
    public class HealthCheckController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Health()
        {
            return Ok("Teste Publish");
        }
    }
}