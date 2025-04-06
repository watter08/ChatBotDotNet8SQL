using ImproveAbilityInSqlAndC_.Application.DTOs;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Patterns;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Repositories;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Services;
using System.Data;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Services.Question
{
    public class QuestionService: IQuestionService
    {
        private IGenericRepository _repository;
        private IQueryFactory _queryFactory;
        private IQuestionRepository _questionRepository;
        public QuestionService(IGenericRepository repository, IQueryFactory queryFactory, IQuestionRepository questionRepository)
        {
            _repository = repository;
            _queryFactory = queryFactory;
            _questionRepository = questionRepository;
        }

        public async Task<ApiResponse<string>?> GetIAAnswerByQuestion(string question)
        {
            ApiResponse<string>? Response = default;
            try
            {
                List<string>? Answers = await GetTopInfoQuestions(question);
                if(Answers == null || Answers.Count == 0)
                {
                    return ApiResponse<string>.Success("No se encontro una respuesta para tu pregunta!");
                }
                string Result = await _questionRepository.GetIAResponse(Answers, question);
                Response = ApiResponse<string>.Success(Result);
                return Response;
            }catch
            {
                return Response;
            }
        }

        public async Task<List<string>?> GetTopInfoQuestions(string question)
        {
            string query = _queryFactory.GetQuery("answerResponseByQuestion");
            string sql = string.Format(query, $"'{question}'", $"'{question}'");
            List<string>? response = await ExecuteQueryAndGetAnswer(sql);
            return response;
        }


        private async Task<List<string>?> ExecuteQueryAndGetAnswer(string query)
        {
            List<string>? response = default;
            try
            {
                DataTable dt = await _repository.ExecuteQueryAsync(query);
                response = ConvertDataTableToList(dt);
                return response;
            }
            catch
            {
                return response;
            }
        }

        private static List<string> ConvertDataTableToList(DataTable dt)
        {
            return [.. dt.AsEnumerable()
                     .Select(row => row.Field<string>("Response"))
                     .Where(static response => !string.IsNullOrEmpty(response))];
        }

    }
}
