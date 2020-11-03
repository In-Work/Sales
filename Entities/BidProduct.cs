using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("BidProdcut")]
    public class BidProduct
    {
        [Key]
        public int Id { get; set; }

        public int BidId { get; set; }
        public virtual Bid Bid { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Decimal Summa
        {
            get
            {
                return Math.Round(Quantity * Price, 2);
            }
        }
    }
}
