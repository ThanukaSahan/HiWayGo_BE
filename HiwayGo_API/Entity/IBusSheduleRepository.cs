using HiwayGo_API.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Repository
{
    public interface IBusSheduleRepository
    {
        Task<IEnumerable<BusShedule>> SelectAllAsync();
        Task<BusShedule?> SelectByIdAsync(Guid id);
        Task<BusShedule> InsertAsync(BusShedule busShedule);
        Task UpdateAsync(BusShedule busShedule);
        Task<bool> DeleteAsync(Guid id);
    }
}