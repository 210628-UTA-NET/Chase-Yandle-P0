using System;
using Models;
using System.Collections.Generic;
using BL;
using System.Globalization;

namespace UI
{
    public class CustInMenu : IMenu
    {
        private ICustomerBL _custBL;
        private static Customers add = new Customers();
        public CustInMenu(ICustomerBL p_custBL)
        {
            _custBL=p_custBL;
        }

        public void Menu()
        {
            Console.WriteLine("----New Customer Input----");
            Console.WriteLine("Name: "+add.cName);
            Console.WriteLine("Address: "+add.cStreet+" "+add.cCity+" "+add.cState);
            Console.WriteLine("Phone Number: "+add.cPhone);
            Console.WriteLine("Email: "+add.cEmail);
            Console.WriteLine("Birthday: "+add.cBDay);
            Console.WriteLine("Age: "+add.ageNullIfZero);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[0] to return to main menu");
            Console.WriteLine("[1] to add current customer data");
            Console.WriteLine("[2] to add customer name");
            Console.WriteLine("[3] to add customer address");
            Console.WriteLine("[4] to add customer phone number");
            Console.WriteLine("[5] to add customer email");
            Console.WriteLine("[6] to clear current customer data");
            Console.WriteLine("[7] to add customer age in format MM-dd-yyyy");

        }
        public MenuTitle UInput()
        {
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
            switch (choice)
            {
                case "0":
                ClearCustomer();
                return MenuTitle.BaseMenu;
                case "1":
                _custBL.AddCustomer(add);
                Console.WriteLine("Customer Added!  Press Enter to Continue");
                Console.ReadLine();
                ClearCustomer();
                return MenuTitle.CustInputMenu;
                case "2":
                Console.WriteLine("Name:");
                add.cName=Console.ReadLine();
                return MenuTitle.CustInputMenu;
                case "3":
                Console.WriteLine("Street:");
                add.cStreet=Console.ReadLine();
                Console.WriteLine("City:");
                add.cCity=Console.ReadLine();
                Console.WriteLine("State:");
                add.cState=Console.ReadLine();
                return MenuTitle.CustInputMenu;
                case "4":
                Console.WriteLine("Phone Number:");
                add.cPhone=Console.ReadLine();
                return MenuTitle.CustInputMenu;
                case "5":
                Console.WriteLine("Email:");
                add.cEmail=Console.ReadLine();
                return MenuTitle.CustInputMenu;
                case "6":
                ClearCustomer();
                return MenuTitle.CustInputMenu;
                default:
                return MenuTitle.Error;
                case "7":
                
                Console.WriteLine("Birthday in MM-dd-yyyy: ");
                add.cBDay=Console.ReadLine();
                return MenuTitle.CustInputMenu;
            }          
        }

        private void ClearCustomer()
        {
            add=new Customers();
        }
    }
}