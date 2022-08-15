using AutoMapper;
using AMS.Data;
using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap(); 
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, EditLeaveAllocationVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Tenant, TenantVM>().ReverseMap();
            CreateMap<Room, RoomVM>().ReverseMap();
            CreateMap<Reservation, ReservationVM>().ReverseMap();
            CreateMap<Parking, ParkingVM>().ReverseMap();
        }
    }
}
