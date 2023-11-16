using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdHotel { get; set; }
        [Required]
        public int IdRoomDetails { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public decimal Descount{ get; set; }
        [Required]
        public decimal Net { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
         public DateTime DateInvoice { get; set; }
        [Required]
        public DateTime DataFrom{ get; set; }
        [Required]
        public decimal DateTo { get; set; }
        [Required]
        public int IUserId { get; set; }
    }
}
