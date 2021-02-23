using System;
using System.ComponentModel.DataAnnotations;

namespace MMT.Domain.Model
{
    public class CustomerModel : AddressModel
    {
        [Key]        
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool WebSite { get; set; }
        public DateTime LastLoggedIn { get; set; }       
        public string PreferredLanuage { get; set; }
        //public  Order Order  { get; set; };
    }
}
