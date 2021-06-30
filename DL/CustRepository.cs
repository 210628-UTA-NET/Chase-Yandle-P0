using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace DL
{
    public class CustRepository : IRepository
    {
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
             List<Customers> aList;
            aList = GetAllCustomers();
            aList.Add(p_cust);
            _jsonString=JsonSerializer.Serialize(aList,indent);
            File.WriteAllText(_custFilePath,_jsonString);
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
            List<Customers> cList;
            cList = JsonSerializer.Deserialize<List<Customers>>(_jsonString);
            return cList;
        }

        public Customers GetCustomer(Customers p_cust)
        {
            throw new NotImplementedException();
        }
    }
}