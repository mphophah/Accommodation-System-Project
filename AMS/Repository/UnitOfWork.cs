using AMS.Contracts;
using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private  IGenericRepository<LeaveType> _leaveTypes;
        private  IGenericRepository<LeaveRequest> _leaveRequests;
        private  IGenericRepository<LeaveAllocation> _leaveAllocations;
        private  IGenericRepository<Tenant> _Tenants;
        private  IGenericRepository<Room> _Rooms;
        private IGenericRepository<Reservation> _Reservation;
        private IGenericRepository<Parking> _Parkings;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<LeaveType> LeaveTypes
            => _leaveTypes ??= new GenericRepository<LeaveType>(_context);
            
        public IGenericRepository<LeaveRequest> LeaveRequests
              => _leaveRequests ??= new GenericRepository<LeaveRequest>(_context);
        public IGenericRepository<LeaveAllocation> LeaveAllocations
              => _leaveAllocations ??= new GenericRepository<LeaveAllocation>(_context);
        public IGenericRepository<Tenant> Tenants
            => _Tenants ??= new GenericRepository<Tenant>(_context);
        public IGenericRepository<Room> Rooms
            => _Rooms ??= new GenericRepository<Room>(_context);
        public IGenericRepository<Reservation> Reservations
            => _Reservation ??= new GenericRepository<Reservation>(_context);

        public IGenericRepository<Parking> Parkings
            => _Parkings ??= new GenericRepository<Parking>(_context);


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if(dispose)
            {
                _context.Dispose();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
