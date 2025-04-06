namespace ImproveAbilityInSqlAndC_.Application.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<string> GetIAResponse(List<string> Answers, string question);
    }
}
