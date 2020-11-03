using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            Bids = new HashSet<Bid>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            Prices = new HashSet<Price>();
            Transfers = new HashSet<Transfer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public bool Enabled { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
