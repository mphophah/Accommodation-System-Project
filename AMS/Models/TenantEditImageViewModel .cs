namespace AMS.Models
{
    public class TenantEditImageViewModel : TenantUploadImageViewModel
    {
        public int Id { get; set; }
        public string ExistingFile { get; set; }
    }
}
