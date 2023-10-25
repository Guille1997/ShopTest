using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Core
{
    [Table("Store")]
    public class Store
    {
        [Key]
        public int ID { get; set; }
        
        public string Branch { get; set; }

        public string Address { get; set; } 
    }
}
