using ImproveAbilityInSqlAndC_.Application.DTOs;

namespace ImproveAbilityInSqlAndC_.Application.Interfaces.Services
{
    public interface IQuestionService
    {
        Task<List<string>?> GetTopInfoQuestions(string question);
        Task<ApiResponse<string>?> GetIAAnswerByQuestion(string question);
    }
}
