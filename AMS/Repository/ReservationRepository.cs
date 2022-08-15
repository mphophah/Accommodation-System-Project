using AMS.Contracts;
using AMS.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMS.Repository
{
    public class ReservationRepository : IReservation
    {
        private readonly ApplicationDbContext _db;

        public ReservationRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Reservation entity)
        {
            await _db.Reservations.AddAsync(entity);
            return await Save();
        }

        public Task<bool> Delete(Reservation entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Reservation>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> FindById(int id)
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

        public Task<bool> Update(Reservation entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
