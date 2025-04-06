using ImproveAbilityInSqlAndC_.Application.DTOs;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Services;
using ImproveAbilityInSqlAndC_.Application.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace ImproveAbilityInSqlAndC_.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IProductServices _services;
        public QuestionsController(IProductServices productServices)
        {
            _services = productServices;
        }

        [HttpPost("GetIAAnswerForFaqQuestion")]
        public async Task<IActionResult> GetIAAnswerForFaqQuestion([FromBody] RUserQuestion QuestionData)
        {
            ApiResponse<List<DtoProducts>> response = await _services.GetMoreExpensiveProductByCategory();
            return Ok(response);
        }
    }
}
