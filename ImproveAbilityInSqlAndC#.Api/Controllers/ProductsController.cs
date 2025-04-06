using ImproveAbilityInSqlAndC_.Application.DTOs;
using ImproveAbilityInSqlAndC_.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImproveAbilityInSqlAndC_.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductsController(IProductServices productServices)
        {
            _services = productServices;
        }

        [HttpGet("GetMaxExpensiveProductByCategory")]
        public async Task<IActionResult> GetMaxExpensiveProductByCategory()
        {
            ApiResponse<List<DtoProducts>> response = await _services.GetMoreExpensiveProductByCategory();
            return Ok(response);
        }

        [HttpGet("GetMiddleProductPriceByMonth")]
        public async Task<IActionResult> GetMiddleProductPriceByMonth()
        {
            ApiResponse<List<DtoProducts>> response = await _services.GetMiddleProductPriceByMonth();
            return Ok(response);
        }

        [HttpGet("GetMoreExpensiveProductByCategoryAndPosition/{position}")]
        public async Task<IActionResult> GetMoreExpensiveProductByCategoryAndPosition(int position)
        {
            ApiResponse<List<DtoProducts>> response = await _services.GetMoreExpensiveProductByCategoryAndPosition(position);
            return Ok(response);
        }
    }
}
