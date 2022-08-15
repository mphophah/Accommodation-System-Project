using System.ComponentModel.DataAnnotations;

namespace AMS.Data
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public string RoomNumber { get; set; }
        public string Block { get; set; }
        public int Floor { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string RoomType { get; set; }
    }
    
}
