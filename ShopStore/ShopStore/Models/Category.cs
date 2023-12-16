using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ShopStore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ParentID { get; set; }
        public List<Category> Children { get; set; } = new List<Category>();
        public List<Product> Products { get; set; }
        public void AddChild(Category child)
        {
            if (!Children.Contains(child))
            {
                Children.Add(child);
            }
        }
    }
}
