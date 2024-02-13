using System.Text.Json.Serialization;

namespace Amg_Ingressos_aqui_notificacao_api.Dto
{
    public class JwtDto
    {
        public JwtDto()
        {
            JwtToken = string.Empty;
        }
        
        [JsonPropertyName("jwtToken")]
        public string JwtToken { get; set; }
    }
}