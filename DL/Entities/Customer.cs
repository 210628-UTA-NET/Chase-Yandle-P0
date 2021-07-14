using System;
using System.Collections.Generic;

#nullable disable

namespace DL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            SystemsOwneds = new HashSet<SystemsOwned>();
        }

        public string CustomerId { get; set; }
        public string StoreAddedAt { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual Location StoreAddedAtNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SystemsOwned> SystemsOwneds { get; set; }
    }
}
