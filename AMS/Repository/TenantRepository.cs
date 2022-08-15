using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class TenantRepository : ITenantRepository
    {
        private readonly ApplicationDbContext _db;

        public TenantRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Tenant entity)
        {
            await _db.Tenants.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Tenant entity)
        {
            _db.Tenants.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Tenant>> FindAll()
        {
             var tenants = await _db.Tenants.ToListAsync();
             return tenants;
        }

        public Task<Tenant> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(Tenant entity)
        {
            _db.Tenants.Update(entity);
            return await Save();
        }
    }

}
