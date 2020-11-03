using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sales.Entities
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            BidProducts = new HashSet<BidProduct>();
            Orders = new HashSet<Order>();
            Transfers = new HashSet<Transfer>();
            Prices = new HashSet<Price>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }

        public virtual ICollection<BidProduct> BidProducts { get; set; }      //Продажи
        public virtual ICollection<Order> Orders { get; set; }                //Заказы
        public virtual ICollection<Transfer> Transfers { get; set; }          //Передвижение
        public virtual ICollection<Price> Prices { get; set; }                //Цены

        public virtual decimal ActualPrice
        {
            get
            {
                if (Prices.Count > 0)
                {
                    return Prices.OrderByDescending(p => p.Date).First().Value;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
