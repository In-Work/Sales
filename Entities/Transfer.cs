using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Transfer")]
    public class Transfer
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int StoreAtId { get; set; }
        public virtual Store StoreAt { get; set; }

        public int StoreToId { get; set; }
        public virtual Store StoreTo { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
