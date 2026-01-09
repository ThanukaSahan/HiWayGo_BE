using HiwayGo_API.Entity;
using HiwayGo_API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiwayGo_API.Logic
{
    public class BusDetailLogic : IBusDetailLogic
    {
        private readonly IBusDetailRepository _repo;

        public BusDetailLogic(IBusDetailRepository repo)
        {
            _repo = repo;
        }

        public async Task<BusDetail> CreateAsync(BusDetail detail)
        {
            if (detail == null) throw new ArgumentNullException(nameof(detail));
            return await _repo.InsertAsync(detail);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<BusDetail>> GetAllAsync()
        {
            return await _repo.SelectAllAsync();
        }

        public async Task<BusDetail?> GetByIdAsync(Guid id)
        {
            return await _repo.SelectByIdAsync(id);
        }

        public async Task<BusDetail?> GetByOwnerAsync(Guid ownerId)
        {
            return await _repo.GetByOwnerAsync(ownerId);
        }

        public async Task UpdateAsync(BusDetail detail)
        {
            if (detail == null) throw new ArgumentNullException(nameof(detail));
            await _repo.UpdateAsync(detail);
        }
    }
}