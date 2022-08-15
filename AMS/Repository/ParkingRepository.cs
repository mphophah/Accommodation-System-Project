using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class ParkingRepository : IParkingRepository 
    {
        private readonly ApplicationDbContext _db;

        public ParkingRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Parking entity)
        {
            await _db.Parkings.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Parking entity)
        {
            _db.Parkings.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Parking>> FindAll()
        {
             var tenants = await _db.Parkings.ToListAsync();
             return tenants;
        }

        public Task<Parking> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.Parkings.AnyAsync(q => q.Id == id);
            return exists;
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(Parking entity)
        {
            _db.Parkings.Update(entity);
            return await Save();
        }
    }

}
