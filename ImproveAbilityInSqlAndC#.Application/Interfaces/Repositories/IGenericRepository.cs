using System.Data;

namespace ImproveAbilityInSqlAndC_.Application.Interfaces.Repositories
{
    public interface IGenericRepository
    {
        Task<DataTable> ExecuteQueryAsync(string query);
    }
}
