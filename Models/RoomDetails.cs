using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class RoomDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Image2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Image3 { get; set; }
        [Required]
        [StringLength(50)]
        public string Food { get; set; }
        [Required]
        [StringLength(50)]
        public string Futures { get; set; }
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdHotels { get; set; }

    }
}
