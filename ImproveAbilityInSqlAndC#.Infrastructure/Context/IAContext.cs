using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Context
{
    public class IAContext
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IAContext> _logger;
        private const string BaseUrl = "http://localhost:11434/api/generate";

        public IAContext(HttpClient httpClient, ILogger<IAContext> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string> QueryAsync(string prompt, string model = "llama3")
        {
            var request = new
            {
                model = model,
                prompt = prompt,
                stream = false
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var response = await _httpClient.PostAsync(BaseUrl, content);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JObject.Parse(json);
                return result["response"]?.ToString() ?? "La IA no devolvió una respuesta.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consultando IA desde IAContext");
                return "Ocurrió un error al consultar la IA.";
            }
        }
    }
}