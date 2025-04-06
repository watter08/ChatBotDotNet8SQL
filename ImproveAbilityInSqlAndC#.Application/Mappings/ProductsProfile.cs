using AutoMapper;
using ImproveAbilityInSqlAndC_.Application.DTOs;
using System.Data;

namespace ImproveAbilityInSqlAndC_.Application.Mappings
{
    internal class ProductsProfile: Profile
    {
        public ProductsProfile()
        {
            CreateMap<DataRow, DtoProducts>()
                .ForMember(dest => dest.id,
                    opt => opt.MapFrom(src => src.Table.Columns.Contains("id") && src["id"] != DBNull.Value
                        ? Convert.ToInt32(src["id"])
                        : 0))
                .ForMember(dest => dest.ProductName,
                    opt => opt.MapFrom(src => src.Table.Columns.Contains("name") && src["name"] != DBNull.Value
                        ? src["name"].ToString()
                        : string.Empty))
                .ForMember(dest => dest.productCategory,
                    opt => opt.MapFrom(src => src.Table.Columns.Contains("category") && src["category"] != DBNull.Value
                        ? src["category"].ToString()
                        : string.Empty))
                .ForMember(dest => dest.details,
                    opt => opt.MapFrom(src => src.Table.Columns.Contains("description") && src["description"] != DBNull.Value
                        ? src["description"].ToString()
                        : string.Empty))
                .ForMember(dest => dest.price,
                    opt => opt.MapFrom(src => src.Table.Columns.Contains("price") && src["price"] != DBNull.Value
                        ? Convert.ToDecimal(src["price"])
                        : 0m))
                .ForMember(dest => dest.createdAt,
                    opt => opt.MapFrom(src => src.Table.Columns.Contains("createdAt") && src["createdAt"] != DBNull.Value
                        ? Convert.ToDateTime(src["createdAt"])
                        : DateTime.MinValue))
                .ReverseMap();
        }
    }

    public class ProductDataTableMapper
    {
        private readonly IMapper _mapper;

        public ProductDataTableMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductsProfile>());
            _mapper = config.CreateMapper();
        }
        public List<DtoProducts> MapDataTableToList(DataTable table)
        {
            List<DtoProducts> entity = new();
            foreach (DataRow row in table.Rows)
            {
                entity.Add(_mapper.Map<DtoProducts>(row));
            }
            return entity;
        }
    }
}
