using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Core
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int Code { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int Stock { get; set; }
    }
}
