using System;
using Models;
using System.Collections.Generic;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            IMenu newMenu = new BeginMenu();
            bool loop = true;
            string location = "Begin";
            while(loop)
            {
                Console.Clear();
                newMenu.Menu();
                location = newMenu.UInput();

                switch(location)
                {
                    case "Begin":
                    newMenu = new BeginMenu();
                    break;
                    case "MInput":
                    newMenu = new CustInMenu();
                    break;
                    case "MRead":
                    newMenu = new CustRdMenu();
                    break;
                    case "Exit":
                    CustRdMenu.CustList();
                    Console.WriteLine("Thank you for using this program!");
                    loop=false;
                    break;
                    case "Read":
                    CustRdMenu.CustList();
                    Console.WriteLine("Enter any key to return to the main menu");
                    Console.ReadLine();
                    newMenu = new BeginMenu();
                    break;
                    default:
                    Console.WriteLine("That input was not valid, please try again!");
                    break;
                }
            }
        }
    }
}
