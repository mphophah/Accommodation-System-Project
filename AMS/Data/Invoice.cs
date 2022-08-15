using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }
        [ForeignKey("ParkingId")]
        public Parking Parking { get; set; }
        public int ParkingId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        
    }
    
}
