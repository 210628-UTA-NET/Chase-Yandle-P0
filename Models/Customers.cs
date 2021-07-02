using System;
using System.Collections.Generic;

namespace Models
{
    public class Customers
    {
        public string cName { get; set; }
        public string cAddr { get; set; }
        public string cPhone { get; set; }
        public string cEmail { get; set; }
        public List<string> cOrders { get; set; }
    }

}