using AMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class ParkingVM
    {
        public int Id { get; set; }
        [Display(Name="Parking Number")]
        public string ParkingNumber { get; set; }
        [Display(Name="Parking Type")]
        public string ParkingType { get; set; }
        [Display(Name="Amount")]
        public decimal Amount { get; set; }
        [Display(Name="Tenant Name")]
        public int TenantId { get; set; }
        [Display(Name="Full Name")]
        public Tenant Tenant { get; set; }
        public IEnumerable<SelectListItem> TenantList {get; set;}
        // public string TenantFullName { get; set; }


    }
    
}
