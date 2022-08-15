using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMS.Data;

namespace AMS.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<LeaveType> LeaveTypes { get; }
        IGenericRepository<LeaveRequest> LeaveRequests { get; }

        IGenericRepository<LeaveAllocation> LeaveAllocations { get; }
        IGenericRepository<Tenant> Tenants { get; }
        IGenericRepository<Room> Rooms { get; }
        IGenericRepository<Reservation> Reservations { get; }
        IGenericRepository<Parking> Parkings { get; }
        Task Save();
        
    }
}
