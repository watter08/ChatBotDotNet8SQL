using ImproveAbilityInSqlAndC_.Application.Interfaces.Repositories;
using ImproveAbilityInSqlAndC_.Infrastructure.Context;
using System.Data;

namespace ImproveAbilityInSqlAndC_.Infrastructure.Repositories
{
    public class GenericRepository: IGenericRepository
    {
        private readonly AdoNetContext _context;
        public GenericRepository(AdoNetContext context)
        {
            _context = context;
        }
        public async Task<DataTable> ExecuteQueryAsync(string query)
        {
            return await _context.ExecuteQueryAsync(query);
        }
    }
}
