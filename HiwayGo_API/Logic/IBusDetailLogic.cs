using HiwayGo_API.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public interface IBusDetailLogic
    {
        Task<IEnumerable<BusDetail>> GetAllAsync();
        Task<BusDetail?> GetByIdAsync(Guid id);
        Task<BusDetail?> GetByOwnerAsync(Guid ownerId);
        Task<BusDetail> CreateAsync(BusDetail detail);
        Task UpdateAsync(BusDetail detail);
        Task<bool> DeleteAsync(Guid id);
    }
}