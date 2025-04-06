namespace ImproveAbilityInSqlAndC_.Domain.Consts.Queries.Questions
{
    public class QuestionQueries
    {
        public static string getAnswerResponseByQuestion => @"
            ;WITH FaqQuestion AS 
			(
				SELECT 
					Question,
					Answer					AS Response
				FROM IA.Faqs
			),
			CTE_IAResponses AS 
			(
				SELECT 
					UQ.UserQuestion			AS Question,
					IAR.IAAnswer			AS Response
				FROM IA.UserQuestion		UQ
				INNER JOIN IA.IAResponse	IAR ON UQ.Id = IAR.UserQuestionId
			)
			SELECT DISTINCT Response
			FROM FaqQuestion
			WHERE Question = {0} 

			UNION ALL

			SELECT DISTINCT Response
			FROM CTE_IAResponses
			WHERE Question = {1}
			";
    }
}
