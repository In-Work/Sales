using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Direction")]
    public class Direction
    {
        public Direction()
        {
            Bids = new HashSet<Bid>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string BidName { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderName { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentName { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public virtual int MultiplierBid
        {
            get { return Id == 1 ? 1 : -1; }
        }

        public virtual int MultiplierPay
        {
            get { return Id == 1 ? -1 : 1; }
        }
    }
}