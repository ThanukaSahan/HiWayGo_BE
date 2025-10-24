using HiwayGo_API.Entity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HiwayGo_API.Repository
{
    public interface IBusDetailRepository : IGenericRepository<BusDetail>
    {
        Task<BusDetail?> GetByOwnerAsync(Guid ownerId);

        // CRUD convenience
        Task<BusDetail> InsertAsync(BusDetail detail);
        Task<IEnumerable<BusDetail>> SelectAllAsync();
        Task<BusDetail?> SelectByIdAsync(Guid id);
        Task UpdateAsync(BusDetail detail);
        Task<bool> DeleteAsync(Guid id);
    }
}
