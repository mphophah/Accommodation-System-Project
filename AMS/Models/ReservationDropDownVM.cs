using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Models
{
    public class ReservationDropDownVM
    {
        public IEnumerable<SelectListItem> TenantList { get; set; }
        public IEnumerable<SelectListItem> RoomList { get; set; }
    }
}
