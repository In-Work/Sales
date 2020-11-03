using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sales.Entities
{
    [Table("Partner")]
    public class Partner
    {
        public Partner()
        {
            Bids = new HashSet<Bid>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(9)]
        [RegularExpression(@"[А-Я0-9]{9}$", ErrorMessage = "Укажите УНП в правильном формате!")]
        public string UNP { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public bool IsSupplier { get; set; }

        public bool IsPurchaser { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}