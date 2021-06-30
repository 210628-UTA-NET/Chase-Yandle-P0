using System;
using Models;
using System.Collections.Generic;
using BL;
using DL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            IMenu newMenu = new BeginMenu();
            bool loop = true;
            MenuTitle location = MenuTitle.BaseMenu;
            while(loop)
            {
                Console.Clear();
                newMenu.Menu();
                location = newMenu.UInput();

                switch(location)
                {
                    case MenuTitle.BaseMenu:
                    newMenu = new BeginMenu();
                    break;
                    case MenuTitle.CustInputMenu:
                    newMenu = new CustInMenu(new CustomerBL(new CustRepository()));
                    break;
                    case MenuTitle.CustReadoutMenu:
                    newMenu = new CustRdMenu(new CustomerBL(new CustRepository()));
                    break;
                    case MenuTitle.Exit:
                    Console.Clear();
                    Console.WriteLine("Thank you for using this program!");
                    loop=false;
                    break;
                    default:
                    Console.WriteLine("That input was not valid, please try again!");
                    break;
                }
            }
        }
    }
}
