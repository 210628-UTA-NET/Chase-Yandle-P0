using System;
using Models;
using System.Collections.Generic;
using BL;
using DL;
using System.Threading;

namespace UI
{
    public class CustOrdSearchMenu : IMenu
    {
        public static Orders result = new Orders();
        private Orders filter = new Orders();
        List<Orders> readout = new List<Orders>();
        private OrdersBL _orderBL;
        public bool noFilter = true;
        public CustOrdSearchMenu(OrdersBL p_orderBL)
        {
            _orderBL=p_orderBL;
        }
        public void Menu()
        {
            if (noFilter)
            {
                readout=_orderBL.GetAllOrders();
                Console.WriteLine("----Order Search Menu----");
                Console.WriteLine("[0] to return to the order selection menu");
                Console.WriteLine("[1] to retrieve all orders ("+readout.Count+")");
                Console.WriteLine("[2] to apply search filters");
            } else
            {
                Console.WriteLine("----Order Search Menu----");
                Console.WriteLine("[0] to return to the order selection menu");
                Console.WriteLine("[1] to retrieve filtered list of orders ("+readout.Count+")");
                Console.WriteLine("[2] to apply more search filters");
                Console.WriteLine("[3] to clear all search filters");
            }

        }
        public MenuTitle UInput()
        {
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                return MenuTitle.OrderSearchMenu;
                case "1":
                OrderList(readout);
                return MenuTitle.CustomerOrderSearchMenu;
                case "2":
                FilterOrders();
                noFilter=false;
                return MenuTitle.CustomerOrderSearchMenu;
                case "3":
                if (noFilter)
                {
                    return MenuTitle.Error;
                } else
                {
                    noFilter=true;
                    return MenuTitle.CustomerOrderSearchMenu;
                }
                default:
                return MenuTitle.Error;
            }
        }
        public void OrderList(List<Orders> reading)
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine("Order List");
            foreach (Orders ord in reading)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(i+".  Order ID#: "+ord.oNumber +" | Price: "+ ord.oTotalPrice +" | Customer: "+ ord.oCustomerNumber);
                Console.WriteLine("=======================================");
                i++;
            }
            Console.WriteLine("End of list");
            Console.WriteLine("Enter 0 to return to search menu");

                Console.WriteLine("Enter the number of the order that you would like to view");
            int choice = int.Parse(Console.ReadLine());
            if (choice==0)
            {
                Console.WriteLine("Returning to customer search menu");
            } else if (choice<=reading.Count)
            {

                
                ViewOrder(reading[(choice-1)]);
                
            } else
            {
                Console.WriteLine("That input was not valid, please try again!");
            }
        }

        public void ViewOrder(Orders toBeViewed)
        {
            LineItemBL _lineitemBL = new LineItemBL(new LineRepository());
            bool loop = true;
            int i=1;
            while (loop)
            {
            Console.WriteLine("----Order Viewing Interface----");
            Console.WriteLine("Order ID: "+toBeViewed.oNumber);
            Console.WriteLine("Customer Number: "+toBeViewed.oCustomerNumber);
            Console.WriteLine("Store Number: "+toBeViewed.oStoreNumber);
            Console.WriteLine("Date and Time: "+toBeViewed.oDateAndTime);
            foreach (string item in toBeViewed.oLineItemNumbers)
            {
                LineItems _lineItem=_lineitemBL.GetItemByLine(item);
                Console.WriteLine(i+".  "+_lineItem.liGame+_lineItem.liSystem+"   "+_lineItem.liQuantity);
                i++;
            }
            i=1;
            Console.WriteLine("Total Price: "+toBeViewed.oTotalPrice);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Press enter to return to search menu");
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
        }
    }        

    private void FilterOrders()
    {
        string gameTarget="";
        string systemTarget="";
        bool loop = true;
            while (loop)
            {
            Console.WriteLine("----Order Filter Interface----");
            Console.WriteLine("Order Number: "+filter.oNumber);
            Console.WriteLine("Customer Number: "+filter.oCustomerNumber);
            Console.WriteLine("Store Number: "+filter.oStoreNumber);
            Console.WriteLine("Game: "+gameTarget);
            Console.WriteLine("Console: "+systemTarget);
            Console.WriteLine("Total Price: "+filter.oTotalPrice);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[0] to remove filters and return to customer order search menu");
            Console.WriteLine("[1] to use the selected filters");
            Console.WriteLine("[2] to filter order number");
            Console.WriteLine("[3] to filter Customer Number");
            Console.WriteLine("[4] to filter Store Number");
            Console.WriteLine("[5] to filter by games within order");
            Console.WriteLine("[6] to filter by systems within order");
            Console.WriteLine("[7] to filter based on maximum price");
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
            switch (choice)
            {
                case "0":
                    noFilter=true;
                    loop=false;
                    filter=new Orders();
                    break;
                case "1":
                    loop=false;
                    readout=_orderBL.FilterOrder(filter,gameTarget,systemTarget);
                    Console.WriteLine("Filter Applied!  Press Enter to Continue");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Order Number:");
                    filter.oNumber=Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Customer Number:");
                    filter.oCustomerNumber=Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Store Number:");
                    filter.oStoreNumber=Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Product to search for:");
                    gameTarget=Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("Product to search for:");
                    systemTarget=Console.ReadLine();
                    break;
                case "7":
                    Console.WriteLine("Maximum Price: ");
                    filter.oTotalPrice=int.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("That input was not valid, please try again!");
                    break;
                }          
            }
        }
    }
}
