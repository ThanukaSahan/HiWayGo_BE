using HiwayGo_API.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public interface IBusModelRepository : IGenericRepository<BusModel>
    {
        Task<BusModel?> GetByModelAsync(string model);

        // CRUD convenience
        Task<BusModel> InsertAsync(BusModel model);
        Task<IEnumerable<BusModel>> SelectAllAsync();
        Task<BusModel?> SelectByIdAsync(Guid id);
        Task UpdateAsync(BusModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
