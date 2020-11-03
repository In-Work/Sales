using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Store")]
    public class Store
    {
        public Store()
        {
            Bids = new HashSet<Bid>();
            TransfersAt = new HashSet<Transfer>();
            TransfersTo = new HashSet<Transfer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Transfer> TransfersAt { get; set; }
        public virtual ICollection<Transfer> TransfersTo { get; set; }
    }
}