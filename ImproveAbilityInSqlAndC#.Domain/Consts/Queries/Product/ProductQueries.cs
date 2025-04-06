namespace ImproveAbilityInSqlAndC_.Domain.Consts.Queries.Product
{
    public class ProductQueries
    {
        public static string getAllProducts => @"Select * from soradb..Products";

        public static string getMoreExpensiveProductByCategory = @"
                ;WITH MaxProductByCategory AS 
				(
					SELECT 
						P.id,
						P.category,
						P.name,
						P.description,
						P.price,
						P.createAt,
						ROW_NUMBER() OVER (PARTITION BY P.category ORDER BY P.price DESC) AS rn
					FROM soradb..Products P 
				)
				SELECT 
					MPBC.id,
					MPBC.category,
					MPBC.name,
					MPBC.description,
					MPBC.price,
					MPBC.createAt
				FROM MaxProductByCategory MPBC
				WHERE MPBC.rn = 1
				ORDER BY MPBC.id";

        public static string getMoreExpensiveProductByCategoryAndPosition = @"
                ;WITH MaxProductByCategory AS 
				(
					SELECT 
						P.id,
						P.category,
						P.name,
						P.description,
						P.price,
						P.createAt,
						ROW_NUMBER() OVER (PARTITION BY P.category ORDER BY P.price DESC) AS rn
					FROM soradb..Products P 
				)
				SELECT 
					MPBC.id,
					MPBC.category,
					MPBC.name,
					MPBC.description,
					MPBC.price,
					MPBC.createAt
				FROM MaxProductByCategory MPBC
				WHERE MPBC.rn = {0}
				ORDER BY MPBC.id";

        public static string getMiddleProductPriceByMonth = @"
                ;WITH MiddleProductPriceByMonth AS 
				(
					SELECT 
						P.id,
						P.category,
						P.name,
						P.description,
						P.price,
						MONTH(P.createAt)														AS DateMonth,
						P.createAt,
						DENSE_RANK() OVER (PARTITION BY MONTH(createAt) ORDER BY price ASC)		AS RnkAsc,
						DENSE_RANK() OVER (PARTITION BY MONTH(createAt) ORDER BY price DESC)	AS RnkDesc
					FROM soradb..Products P
				)
				SELECT *
				FROM MiddleProductPriceByMonth A
				WHERE RnkAsc = RnkDesc OR RnkAsc + 1 = RnkDesc";
    }
}
