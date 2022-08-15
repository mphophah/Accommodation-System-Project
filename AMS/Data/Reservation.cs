using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

    }
    
}
