using ImproveAbilityInSqlAndC_.Application.DTOs;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Patterns;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Repositories;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Services;
using ImproveAbilityInSqlAndC_.Application.Mappings;
using System.Data;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Services.Product
{
    public class ProductServices : IProductServices
    {
        private IGenericRepository _repository;
        private IQueryFactory _queryFactory;
        public ProductServices(IGenericRepository repository, IQueryFactory queryFactory)
        {
            _repository = repository;
            _queryFactory = queryFactory;
        }

        public async Task<ApiResponse<List<DtoProducts>>> GetMoreExpensiveProductByCategory()
        {
            string query = _queryFactory.GetQuery("maxExpensiveProductByCategory");
            ApiResponse<List<DtoProducts>>? response = await ExecuteProductQUERY(query);
            return response;
        }

        public async Task<ApiResponse<List<DtoProducts>>> GetMoreExpensiveProductByCategoryAndPosition(int position)
        {
            string query = string.Format(_queryFactory.GetQuery("maxExpensiveProductByCategoryAndPosition"), position);
            ApiResponse<List<DtoProducts>>? response = await ExecuteProductQUERY(query);
            return response;
        }

        public async Task<ApiResponse<List<DtoProducts>>> GetMiddleProductPriceByMonth()
        {
            string query = _queryFactory.GetQuery("middleProductPriceByMonth");
            ApiResponse<List<DtoProducts>>? response = await ExecuteProductQUERY(query);
            return response;
        }

        private async Task<ApiResponse<List<DtoProducts>>> ExecuteProductQUERY(string query)
        {
            ApiResponse<List<DtoProducts>>? response = default;
            try
            {
                DataTable dt = await _repository.ExecuteQueryAsync(query);
                ProductDataTableMapper mapper = new();
                List<DtoProducts> products = mapper.MapDataTableToList(dt);
                response = ApiResponse<List<DtoProducts>>.Success(products);
                return response;
            }
            catch (Exception ex)
            {
                response = ApiResponse<List<DtoProducts>>.Error(ex.Message);
                return response;
            }
        }
    }
}
