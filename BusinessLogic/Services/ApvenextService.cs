using BusinessData.Interfaces;
using BusinessEntity.Data.Models;
using BusinessLogic.Interfaces;
using Common.ViewModels;

namespace BusinessLogic.Services
{
    public class ApvenextService : IApvenextService
    {
        private readonly IApvenextRepository _repository;

        public ApvenextService(IApvenextRepository repository)
        {
            _repository = repository;
        }

        public async Task<(IEnumerable<ApvenextSql> items, int totalCount)> GetAllAsync(string searchQuery, int pageNumber, int pageSize) => await _repository.GetAllAsync(searchQuery, pageNumber, pageSize);

        public async Task<ApvenextSql> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(ApvenextSql entity) => await _repository.AddAsync(entity);

        public async Task UpdateAsync(ApvenextSql entity) => await _repository.UpdateAsync(entity);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<ApvenextDTO>> GetByStoredProcedureAsync() => await _repository.GetByStoredProcedureAsync();
    }
}
