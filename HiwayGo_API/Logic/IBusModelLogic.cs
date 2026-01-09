using HiwayGo_API.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public interface IBusModelLogic
    {
        Task<IEnumerable<BusModel>> GetAllAsync();
        Task<BusModel?> GetByIdAsync(Guid id);
        Task<BusModel?> GetByModelAsync(string model);
        Task<BusModel> CreateAsync(BusModel model);
        Task UpdateAsync(BusModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}