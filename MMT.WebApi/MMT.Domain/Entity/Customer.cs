﻿namespace MMT.Domain.Entity
{
    public class Customer : Address
    {
        public string Email;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
