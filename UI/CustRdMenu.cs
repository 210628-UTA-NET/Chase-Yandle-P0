using System;
using Models;
using System.Collections.Generic;
using BL;

namespace UI
{
    public class CustRdMenu : IMenu
    {
        private ICustomerBL _custBL;
        public CustRdMenu(ICustomerBL p_custBL)
        {
            _custBL=p_custBL;
        }
        public void Menu()
        {
            Console.WriteLine("----Customer Readout----");
            Console.WriteLine("[0] to return to main menu");
            Console.WriteLine("[1] to retrieve all customer information");
        }
        public MenuTitle UInput()
        {
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                return MenuTitle.BaseMenu;
                case "1":
                List<Customers> readout = _custBL.GetAllCustomers();
                CustList(readout);
                return MenuTitle.BaseMenu;
                default:
                return MenuTitle.CustReadoutMenu;
            }
        }
        public static void CustList(List<Customers> reading)
        {
            Console.Clear();
            
            Console.WriteLine("Customer List");
            foreach (Customers cust in reading)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Index: "+reading.IndexOf(cust)+" | Name: "+cust.cName +" | Address: "+ cust.cAddr +" | Phone: "+ cust.cPhone +" | Email: "+ cust.cEmail);
                Console.WriteLine("=======================================");
            }
            Console.WriteLine("End of list");
            Console.WriteLine("Enter any key to return to the main menu");
            Console.ReadLine();
        }
    }
}