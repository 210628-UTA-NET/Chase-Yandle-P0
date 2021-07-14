using System;
using Models;
using System.Collections.Generic;
using BL;
using System.Globalization;
using System.Threading;

namespace UI
{
    public class CustAddMenu : IMenu
    {
        private CustomerBL _custBL;
        private static Customers cAdd = new Customers();
        private static Systems cSystems = new Systems();

        public CustAddMenu(CustomerBL p_custBL)
        {
            _custBL=p_custBL;
        }

        public void Menu()
        {
            Console.WriteLine("----New Customer Input----");
            Console.WriteLine("Name: "+cAdd.cName);
            Console.WriteLine("Address: "+cAdd.cStreet+" "+cAdd.cCity+", "+cAdd.cState);
            Console.WriteLine("Phone Number: "+cAdd.cPhone);
            Console.WriteLine("Email: "+cAdd.cEmail);
            Console.WriteLine("Birthday: "+cAdd.cBDay);
            Console.WriteLine("Age: "+cAdd.ageNullIfZero);
            Console.WriteLine("Consoles: "+Program.StringListOneLine(cAdd.cSystems));
            Console.WriteLine("---------------------------");
            Console.WriteLine("[0] to return to add menu");
            Console.WriteLine("[1] to add customer to database");
            Console.WriteLine("[2] to add customer name");
            Console.WriteLine("[3] to add customer address");
            Console.WriteLine("[4] to add customer phone number");
            Console.WriteLine("[5] to add customer email");
            Console.WriteLine("[6] to add customer age in format MM-dd-yyyy");
            Console.WriteLine("[7] to add or remove a console this customer owns");
            Console.WriteLine("[8] to clear current customer data");
        }
        public MenuTitle UInput()
        {
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
            switch (choice)
            {
                case "0":
                    ClearCustomer();
                    return MenuTitle.AddMenu;
                case "1":
                    cAdd.cStoreAddedAt=LoginMenu.storeID;
                    cAdd.cID=LoginMenu.storeID+(LoginMenu.customersAddedFrom+1).ToString("0000");
                    _custBL.AddCustomer(cAdd);
                    Console.WriteLine("Customer "+cAdd.cID+" Added!  Press Enter to Continue");
                    Console.ReadLine();
                    ClearCustomer();
                    return MenuTitle.CustomerAddMenu;
                case "2":
                    Console.WriteLine("Name:");
                    cAdd.cName=Console.ReadLine();
                    return MenuTitle.CustomerAddMenu;
                case "3":
                    Console.WriteLine("Street:");
                    cAdd.cStreet=Console.ReadLine();
                    Console.WriteLine("City:");
                    cAdd.cCity=Console.ReadLine();
                    Console.WriteLine("State:");
                    cAdd.cState=Console.ReadLine();
                    return MenuTitle.CustomerAddMenu;
                case "4":
                    Console.WriteLine("Phone Number:");
                    cAdd.cPhone=Console.ReadLine();
                    return MenuTitle.CustomerAddMenu;
                case "5":
                    Console.WriteLine("Email:");
                    cAdd.cEmail=Console.ReadLine();
                    return MenuTitle.CustomerAddMenu;
                case "6":
                    Console.WriteLine("Birthday in MM-dd-yyyy: ");
                    cAdd.cBDay=Console.ReadLine();
                    return MenuTitle.CustomerAddMenu;
                case "7":
                    cAdd.cSystems.Clear();
                    cSystems = new Systems();         
                    AddSystems();
                    return MenuTitle.CustomerAddMenu;  
                case "8":
                    ClearCustomer();
                    return MenuTitle.CustomerAddMenu;
                default:
                    return MenuTitle.Error;
            }          
        }

        private void ClearCustomer()
        {
            cAdd=new Customers();
        }

        private void AddSystems()
        {
            bool test = true;
            string input;
            while (test)
            {
                Console.Clear();
                int stepper=0;
                Console.WriteLine("Consoles: "+Program.StringListOneLine(cAdd.cSystems));
                Console.WriteLine("[0] to go back to customer information input menu");
                foreach (string item in cSystems._availSystems)
                {
                    Console.WriteLine("["+(stepper+1).ToString()+"] to add "+cSystems._availSystems[stepper]);
                    stepper++;
                }
                Console.WriteLine("Add: ");
                input=Console.ReadLine();
                int toIntInput = int.Parse(input);

                if(input == "0")
                {
                    test=false;
                } else if (toIntInput<=cSystems._availSystems.Count)
                {
                    cAdd.cSystems.Add(cSystems._availSystems[toIntInput-1]);
                    cSystems._availSystems.RemoveAt(toIntInput-1);
                }else
                {
                    Console.WriteLine("Input not valid");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}