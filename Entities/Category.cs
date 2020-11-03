using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Entities
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Categories = new HashSet<Category>();             
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public virtual string HName
        {
            get
            {
                string res = "";
                int lvl = GetLvl(Parent);
                for (int i = 0; i < lvl; i++)
                {
                    res += "   ";
                }
                return res + Name;
            }

        }

        private int GetLvl(Category parent)
        {
            if (parent != null)
            {
                return 1 + GetLvl(parent.Parent);
            }
            else
            {
                return 0;
            }
        }
    }
}
