using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMT.Domain.Model
{
    public class CustomerModel : AddressModel
    {
        [Key]
        [Column("CustomerId")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool WebSite { get; set; }
        public DateTime LastLoggedIn { get; set; }       
        public string PreferredLanuage { get; set; }        
    }
}
