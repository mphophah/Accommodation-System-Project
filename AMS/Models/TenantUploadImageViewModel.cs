using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class TenantUploadImageViewModel
    {
        [Display(Name = "File")]
        public IFormFile file { get; set; }
    }
}
