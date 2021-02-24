using System;

namespace MMT.Domain.Entity
{
    public class Customer : Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool WebSite { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public string PreferredLanuage { get; set; }

    }
}
