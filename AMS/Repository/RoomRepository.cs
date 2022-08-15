using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _db;
        
        public RoomRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }

        public async Task<bool> Create(Room entity)
        {
            await _db.Rooms.AddAsync(entity);
            return await Save();
        }

        public Task<bool> Delete(Room entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Room>> FindAll()
        {
             var rooms = await _db.Rooms.ToListAsync();
             return rooms;
        }

        public Task<Room> FindById(int id)
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

        public Task<bool> Update(Room entity)
        {
            throw new System.NotImplementedException();
        }
    }
    
}
