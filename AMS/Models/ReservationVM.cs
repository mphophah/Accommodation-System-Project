using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class ReservationVM
    {
        public int Id { get; set; }
        [Display(Name = "Date In")]
        [Required]
        public string DateIn { get; set; }
        [Display(Name = "Date Out")]
        [Required]
        public string DateOut { get; set; }
        [Display(Name = "Tenant Name")]
        public int TenantId { get; set; }
        public IEnumerable<SelectListItem> TenantList { get; set; }
        [Display(Name = "Room Number")]
        public int RoomId { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }
    }
}
