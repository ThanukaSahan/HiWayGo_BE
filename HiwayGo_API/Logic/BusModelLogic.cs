using HiwayGo_API.Entity;
using HiwayGo_API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public class BusModelLogic : IBusModelLogic
    {
        private readonly IBusModelRepository _repo;

        public BusModelLogic(IBusModelRepository repo)
        {
            _repo = repo;
        }

        public async Task<BusModel> CreateAsync(BusModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _repo.InsertAsync(model);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<BusModel>> GetAllAsync()
        {
            return await _repo.SelectAllAsync();
        }

        public async Task<BusModel?> GetByIdAsync(Guid id)
        {
            return await _repo.SelectByIdAsync(id);
        }

        public async Task<BusModel?> GetByModelAsync(string model)
        {
            if (string.IsNullOrWhiteSpace(model)) return null;
            return await _repo.GetByModelAsync(model);
        }

        public async Task UpdateAsync(BusModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            await _repo.UpdateAsync(model);
        }
    }
}