using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdNumber { get; set; }
        public string Comments { get; set; }
        public string VisitReason { get; set; }
        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }

    }
    
}
