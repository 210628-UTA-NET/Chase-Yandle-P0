using System;
using Models;
using System.Collections.Generic;
using BL;

namespace UI
{
    public class CustInMenu : IMenu
    {
        private ICustomerBL _custBL;
        public CustInMenu(ICustomerBL p_custBL)
        {
            _custBL=p_custBL;
        }
        public void Menu()
        {
            Console.WriteLine("----New Customer Input----");
            Console.WriteLine("[0] to return to main menu");
            Console.WriteLine("Please enter the first and last name of the customer:");
        }
        public MenuTitle UInput()
        {
            string tName;
            string tAddr;
            string tPhone;
            string tEmail;
            string tConfirm;
            string choice = Console.ReadLine();
            if (choice=="0")
            {
                return MenuTitle.BaseMenu;
            }else
            {
                tName=choice;
                Console.WriteLine("Please enter the customer address:");
                tAddr=Console.ReadLine();
                Console.WriteLine("Please enter the customer phone number:");
                tPhone=Console.ReadLine();
                Console.WriteLine("Please enter the customer email:");
                tEmail=Console.ReadLine();

                Console.WriteLine(tName + " / "+tAddr+" / "+tPhone+" / "+tEmail);
                Console.WriteLine("[0] if information is incorrect or you wish to cancel");
                Console.WriteLine("Enter any other key to proceed with customer information import");
                tConfirm=Console.ReadLine();
                if (tConfirm!="0")
                {
                    Customers add = new Customers();
                    add.cName=tName;
                    add.cAddr=tAddr;
                    add.cPhone=tPhone;
                    add.cEmail=tEmail;
                    Console.WriteLine(_custBL.AddCustomer(add).cName);              
                }
                return MenuTitle.CustInputMenu;
                

            }
        }
    }
}