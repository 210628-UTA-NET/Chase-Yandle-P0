using System;
using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepository
    {
        List<Customers> GetAllCustomers();
        Customers GetCustomer(Customers p_cust);
        Customers AddCustomer(Customers p_cust);
    }
}
