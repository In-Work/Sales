using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int DirectionId { get; set; }
        public virtual Direction Direction { get; set; }

        public int BidId { get; set; }
        public virtual Bid Bid { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Summa { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}