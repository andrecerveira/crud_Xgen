using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string PublicPlace { get; set; }
        public string Complement { get; set; }

        public int ClientId { get; set; }
        
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
