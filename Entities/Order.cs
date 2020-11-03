using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int BidId { get; set; }
        public virtual Bid Bid { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}