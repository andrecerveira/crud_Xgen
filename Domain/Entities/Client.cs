using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        //public int ContactId { get; set; }
        //public virtual Contact Contact { get; set; }
    }
}
