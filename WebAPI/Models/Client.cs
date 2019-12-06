using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Name { get; set; }
        
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }
        
        [Phone(ErrorMessage = "Telefone Inválido")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

    }
}
