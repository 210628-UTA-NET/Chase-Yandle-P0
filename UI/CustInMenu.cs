using System;
using Models;
using System.Collections.Generic;
using BL;
using System.Globalization;
using System.Threading;

namespace UI
{
    public class CustInMenu : IMenu
    {
        private ICustomerBL _custBL;
        private static Customers cAdd = new Customers();

        public CustInMenu(ICustomerBL p_custBL)
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
            Console.WriteLine("[0] to return to main menu");
            Console.WriteLine("[1] to add current customer data");
            Console.WriteLine("[2] to add customer name");
            Console.WriteLine("[3] to add customer address");
            Console.WriteLine("[4] to add customer phone number");
            Console.WriteLine("[5] to add customer email");
            Console.WriteLine("[6] to clear current customer data");
            Console.WriteLine("[7] to add customer age in format MM-dd-yyyy");
            Console.WriteLine("[8] to add a console this customer owns");
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
                    _custBL.AddCustomer(cAdd);
                    Console.WriteLine("Customer Added!  Press Enter to Continue");
                    Console.ReadLine();
                    ClearCustomer();
                    return MenuTitle.CustInputMenu;
                case "2":
                    Console.WriteLine("Name:");
                    cAdd.cName=Console.ReadLine();
                    return MenuTitle.CustInputMenu;
                case "3":
                    Console.WriteLine("Street:");
                    cAdd.cStreet=Console.ReadLine();
                    Console.WriteLine("City:");
                    cAdd.cCity=Console.ReadLine();
                    Console.WriteLine("State:");
                    cAdd.cState=Console.ReadLine();
                    return MenuTitle.CustInputMenu;
                case "4":
                    Console.WriteLine("Phone Number:");
                    cAdd.cPhone=Console.ReadLine();
                    return MenuTitle.CustInputMenu;
                case "5":
                    Console.WriteLine("Email:");
                    cAdd.cEmail=Console.ReadLine();
                    return MenuTitle.CustInputMenu;
                case "6":
                    ClearCustomer();
                    return MenuTitle.CustInputMenu;
                default:
                    return MenuTitle.Error;
                    case "7":
                    Console.WriteLine("Birthday in MM-dd-yyyy: ");
                    cAdd.cBDay=Console.ReadLine();
                    return MenuTitle.CustInputMenu;
                case "8":       
                    bool test = true;
                    string input;
                    while (test)
                    {
                        Console.Clear();
                        List<string> tempSystems = new List<string>();
                        tempSystems=Systems._availSystems;
                        int stepper=0;
                        Console.WriteLine("Consoles: "+Program.StringListOneLine(cAdd.cSystems));
                        Console.WriteLine("[0] to go back to customer information input menu");
                        foreach (string item in tempSystems)
                        {
                            Console.WriteLine("["+(stepper+1).ToString()+"] to add "+tempSystems[stepper]);
                            stepper++;
                        }
                        Console.WriteLine("Add: ");
                        input=Console.ReadLine();
                        int toIntInput = int.Parse(input);

                        if(input == "0")
                        {
                            test=false;
                            return MenuTitle.CustInputMenu;
                        } else if (toIntInput<=tempSystems.Count)
                        {
                            cAdd.cSystems.Add(tempSystems[toIntInput-1]);
                            tempSystems.RemoveAt(toIntInput-1);
                        } else
                        {
                            Console.WriteLine("Input not valid");
                            Thread.Sleep(2000);
                        }
                    }
                        return MenuTitle.CustInputMenu;  
            }          
        }

        private void ClearCustomer()
        {
            cAdd=new Customers();
        }
    }
}