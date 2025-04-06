using ImproveAbilityInSqlAndC_.Application.Interfaces.Patterns;
using ImproveAbilityInSqlAndC_.Domain.Consts.Queries.Product;
using ImproveAbilityInSqlAndC_.Domain.Consts.Queries.Questions;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Patterns
{
    public class QueryFactory: IQueryFactory
    {
        private readonly Dictionary<string, string> _queries;

        public QueryFactory()
        {
            _queries = new Dictionary<string, string>
            {
                {"answerResponseByQuestion", QuestionQueries.getAnswerResponseByQuestion },
                {"maxExpensiveProductByCategory", ProductQueries.getMoreExpensiveProductByCategory },
                {"maxExpensiveProductByCategoryAndPosition", ProductQueries.getMoreExpensiveProductByCategoryAndPosition },
                {"middleProductPriceByMonth", ProductQueries.getMiddleProductPriceByMonth }
            };
        }

        public string GetQuery(string queryName)
        {
            return _queries.TryGetValue(queryName, out var query) ? query : throw new KeyNotFoundException($"Query '{queryName}' no encontrada.");
        }
    }
}
