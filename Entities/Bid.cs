using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Bid")]
    public class Bid
    {
        public Bid()
        {
            BidProducts = new HashSet<BidProduct>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int DirectionId { get; set; }
        public virtual Direction Direction { get; set; }

        public int PartnerId { get; set; }
        public virtual Partner Partner { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [Required]
        public int DeliveryTime { get; set; }

        [Required]
        public int PaymentTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<BidProduct> BidProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public virtual string Presentation
        {
            get
            {
                return string.Format("№{0} от {1:dd.MM.yyyy}", Id, Date);
            }
        }
    }
}