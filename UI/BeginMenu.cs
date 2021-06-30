using System;

namespace UI
{
    public class BeginMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("----Welcome to the customer recording system!----");
            Console.WriteLine("[0] to exit program (Warning!  All data will be lost from list but given upon exit)");
            Console.WriteLine("[1] to input customer information");
            Console.WriteLine("[2] to retrieve customer information");
        }
        public string UInput()
        {
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                return "Exit";
                case "1":
                return "MInput";
                case "2":
                return "MRead";
                default:
                return "NA";
            }
        }
    }
}