using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace DL
{
    public class CustRepository : IRepository
    {
        private static List<Customers> cList;
        private const string _custFilePath = "./../DL/Database/Customers.json";
        private string _jsonString;
        JsonSerializerOptions indent = new JsonSerializerOptions{WriteIndented=true};
        public Customers AddCustomer(Customers p_cust)
        {
            try
            {
                _jsonString = File.ReadAllText(_custFilePath);
            }
            catch (System.Exception)
            {
                throw new Exception("The path to customer database is invalid");
            }
            cList = GetAllCustomers();
            cList.Add(p_cust);
            JsonSerializer.Serialize(cList,indent);
            return p_cust;
        }
        public List<Customers> GetAllCustomers()
        {
            try
            {
                _jsonString = File.ReadAllText(_custFilePath);
            }
            catch (System.Exception)
            {
                
                throw new Exception("The path to customer database is invalid");
            }
            cList = JsonSerializer.Deserialize<List<Customers>>(_jsonString);
            return cList;
        }

        public Customers GetCustomer(Customers p_cust)
        {
            throw new NotImplementedException();
        }
    }
}