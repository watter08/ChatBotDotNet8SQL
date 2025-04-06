using ImproveAbilityInSqlAndC_.Application.Interfaces.Repositories;
using ImproveAbilityInSqlAndC_.Infrastructure.Context;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Repositories
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly IAContext _context;
        public QuestionRepository(IAContext iAContext)
        {
            _context = iAContext;
        }
        public async Task<string> GetIAResponse(List<string> Answers, string question)
        {
            string Response = string.Empty;
            try
            {
                var Contexto = string.Join("\n", Answers);
                string prompt = $"""
                    Eres un asistente experto. Basándote en la siguiente información de la base de datos:

                    {Contexto}

                    Responde esta pregunta del usuario:

                    {question}
                """;
                Response = await _context.QueryAsync(prompt);
                return Response;
            }
            catch (Exception ex)
            {
                return Response;
            }
        }
    }
}
