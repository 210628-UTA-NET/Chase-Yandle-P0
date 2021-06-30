using System;
using System.Collections.Generic;
using Models;

namespace BL
{
    public interface ICustomerBL
    {
        List<Customers> GetAllCustomers();
        Customers AddCustomer(Customers _cAdd);
    }
}