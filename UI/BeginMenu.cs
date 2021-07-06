using System;

namespace UI
{
    public class BeginMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("----Welcome to the customer recording system!----");
            Console.WriteLine("[0] to exit program");
            Console.WriteLine("[1] to input customer information");
            Console.WriteLine("[2] to retrieve customer information");
        }
        public MenuTitle UInput()
        {
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                return MenuTitle.Exit;
                case "1":
                return MenuTitle.CustInputMenu;
                case "2":
                return MenuTitle.CustReadoutMenu;
                default:
                return MenuTitle.BaseMenu;
            }
        }
    }
}