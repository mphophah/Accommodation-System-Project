using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class LeaveRequestVM : EditImageViewModel
    {
        public int Id { get; set; }
        public EmployeeVM RequestingEmployee { get; set; }
        [Display(Name = "Employee Name")]
        public string RequestingEmployeeId { get; set; }
        [Display(Name = "Assiged Name")]
        public string AssignedEmployeeId { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Solution Apx Date")]
        [Required]
        [DataType(DataType.Date) ]
        public DateTime EndDate { get; set; }

        [Display(Name = "System Type")]
        public string systemType { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "Device Type")]
        public string deviceType { get; set; }
        [Display(Name = "Priority")]
        public string priority { get; set; }
        [Display(Name = "FileAttached")]
        public string fileAttached { get; set; }

        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }
        [Display(Name = "Approval State")]
        public bool? Approved { get; set; }
        public EmployeeVM ApprovedBy { get; set; }
        [Display(Name = "Approver Name")]
        public string ApprovedById { get; set; }
        public bool Cancelled { get; set; }
        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    }

    public class AdminLeaveRequestViewVM : EditImageViewModel
    {
        [Display(Name = "Total Number Of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }

    public class CreateLeaveRequestVM : EditImageViewModel
    {
        
        [Display(Name = "Start Date")]
        [Required]
        public string StartDate { get; set; }
        [Display(Name = "Solution Apx Date")]
        [Required]
        public string EndDate { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        [Display(Name = "Ticket Reason")]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
        [Display(Name = "System Type")]
        public string systemType { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "Device Type")]
        public string deviceType { get; set; }
        [Display(Name = "Priority")]
        public string priority { get; set; }
        [Display(Name = "FileAttached")]
        public string fileAttached { get; set; }
    }

    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
