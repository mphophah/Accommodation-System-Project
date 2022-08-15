using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }
        public string ParkingNumber { get; set; }
        public string ParkingType { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }

    }
    
}
