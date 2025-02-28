using BusinessEntity.Data.Models;
using Common.ViewModels;

namespace BusinessLogic.Interfaces
{
    internal interface IApvenextService
    {
        Task<(IEnumerable<ApvenextSql> items, int totalCount)> GetAllAsync(string searchQuery, int pageNumber, int pageSize);
        Task<ApvenextSql> GetByIdAsync(int id);
        Task AddAsync(ApvenextSql entity);
        Task UpdateAsync(ApvenextSql entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<ApvenextDTO>> GetByStoredProcedureAsync();
    }
}
