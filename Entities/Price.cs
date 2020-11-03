using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Price")]
    public class Price
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Value { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}