using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class CART
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdHotel { get; set; }

        public int IdRoomDetails { get; set; }
        public decimal Price { get; set; }
        public int IUserId { get; set; }
    }
}
