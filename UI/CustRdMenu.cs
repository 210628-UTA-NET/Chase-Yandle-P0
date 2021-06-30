using System;
using Models;
using System.Collections.Generic;

namespace UI
{
    public class CustRdMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("----Customer Readout----");
            Console.WriteLine("[0] to return to main menu");
            Console.WriteLine("[1] to retrieve all customer information");
        }
        public string UInput()
        {
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                return "Begin";
                case "1":
                return "Read";
                default:
                return "NA";
            }
        }
        public static void CustList()
        {
            Console.Clear();
            Console.WriteLine("Index / Name / Address / Phone / Email");
            Console.WriteLine("=======================================");
            for (int i = 0; i < Models.Customers.cName.Count; i++)
            {
                Console.WriteLine(i + " / " + Models.Customers.cName[i] + " / " + Models.Customers.cAddr[i] + " / " + Models.Customers.cPhone[i] + " / " + Models.Customers.cEmail[i]);
            }
            Console.WriteLine("End of list");
        }
    }
}