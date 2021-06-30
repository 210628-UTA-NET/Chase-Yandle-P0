using System;
using Models;
using System.Collections.Generic;

namespace UI
{
    public class CustInMenu : IMenu
    {

        public void Menu()
        {
            Console.WriteLine("----New Customer Input----");
            Console.WriteLine("[0] to return to main menu");
            Console.WriteLine("Please enter the first and last name of the customer:");
        }
        public string UInput()
        {
            string tName;
            string tAddr;
            string tPhone;
            string tEmail;
            string tConfirm;
            string choice = Console.ReadLine();
            if (choice=="0")
            {
                return "Begin";
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
                    Models.Customers.cName.Add(tName);
                    Models.Customers.cAddr.Add(tAddr);
                    Models.Customers.cPhone.Add(tPhone);
                    Models.Customers.cEmail.Add(tEmail);                 
                }
                return "MInput";
                

            }
        }
    }
}