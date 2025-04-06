using ImproveAbilityInSqlAndC_.Application.DTOs;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImproveAbilityInSqlAndC_.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _services;
        public QuestionsController(IQuestionService questionService)
        {
            _services = questionService;
        }

        [HttpGet("GetIAAnswerForFaqQuestion")]
        public async Task<IActionResult> GetIAAnswerForFaqQuestion(string question)
        {
            ApiResponse<string>? response = await _services.GetIAAnswerByQuestion(question);
            return Ok(response);
        }
    }
}
