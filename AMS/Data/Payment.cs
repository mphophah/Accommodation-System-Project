using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Data
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public decimal PaymentAbount { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
        [ForeignKey("TenantId")]
        public Tenant Tenant { get; set; }
        public int TenantId { get; set; }

    }
    
}
