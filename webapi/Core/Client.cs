using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Core
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ID { get; set; } 

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }


    }
}
