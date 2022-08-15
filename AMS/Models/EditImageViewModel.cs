namespace AMS.Models
{
    public class EditImageViewModel : UploadImageViewModel
    {
        public int Id { get; set; }
        public string ExistingFile { get; set; }
    }
}
