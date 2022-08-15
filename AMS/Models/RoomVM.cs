using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class RoomVM
    {
        public int Id { get; set; }
        [Display(Name="Price")]
        public double Amount { get; set; }
        [Display(Name="Room Number")]
        public string RoomNumber { get; set; }
        [Display(Name="Room Block")]
        public string Block { get; set; }
        [Display(Name="Room Floor")]
        public int Floor { get; set; }
        [Display(Name="Room Status")]
        public string Status { get; set; }
        [Display(Name="Description of The Room")]
        public string Description { get; set; }
        [Display(Name="Type of The Room")]
        public string RoomType { get; set; }
        
    }
    
}
