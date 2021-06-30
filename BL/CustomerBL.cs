using System;
using System.Collections.Generic;
using DL;
using Models;

namespace BL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo=p_repo;
        }

        public Customers AddCustomer(Customers _cAdd)
        {
            return _repo.AddCustomer(_cAdd);
        }

        public List<Customers> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }
    }
}