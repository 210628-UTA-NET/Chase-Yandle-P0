using System;
using Models;
using System.Collections.Generic;
using BL;
using DL;
using System.Threading;

namespace UI
{
    public class StockOrdSearchMenu : IMenu
    {
        public static StockOrders result = new StockOrders();
        private StockOrders filter = new StockOrders();
        List<StockOrders> readout = new List<StockOrders>();
        private StockOrdersBL _orderBL;
        public bool noFilter = true;
        public StockOrdSearchMenu(StockOrdersBL p_orderBL)
        {
            _orderBL=p_orderBL;
        }
        public void Menu()
        {
            if (noFilter)
            {
                readout=_orderBL.GetAllStockOrders();
                Console.WriteLine("----Stock Order Search Menu----");
                Console.WriteLine("[0] to return to the order selection menu");
                Console.WriteLine("[1] to retrieve all Stock orders ("+readout.Count+")");
                Console.WriteLine("[2] to apply search filters");
            } else
            {
                Console.WriteLine("----Order Search Menu----");
                Console.WriteLine("[0] to return to the order selection menu");
                Console.WriteLine("[1] to retrieve filtered list of Stock orders ("+readout.Count+")");
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
                StockOrderList(readout);
                return MenuTitle.StockOrderSearchMenu;
                case "2":
                FilterStockOrders();
                noFilter=false;
                return MenuTitle.StockOrderSearchMenu;
                case "3":
                if (noFilter)
                {
                    return MenuTitle.Error;
                } else
                {
                    noFilter=true;
                    return MenuTitle.StockOrderSearchMenu;
                }
                default:
                return MenuTitle.Error;
            }
        }
        public void StockOrderList(List<StockOrders> reading)
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine("Stock Order List");
            foreach (StockOrders ord in reading)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(i+".  Order ID#: "+ord.soNumber +" | Destination: "+ ord.soDestination +" | Source: "+ ord.soSource);
                Console.WriteLine("=======================================");
                i++;
            }
            Console.WriteLine("End of list");
            Console.WriteLine("Enter 0 to return to search menu");

                Console.WriteLine("Enter the number of the stock order that you would like to view");
            int choice = int.Parse(Console.ReadLine());
            if (choice==0)
            {
                Console.WriteLine("Returning to stock order search menu");
            } else if (choice<=reading.Count)
            {

                
                ViewStockOrder(reading[(choice-1)]);
                
            } else
            {
                Console.WriteLine("That input was not valid, please try again!");
            }
        }

        public void ViewStockOrder(StockOrders toBeViewed)
        {
            LineItemBL _lineitemBL = new LineItemBL(new LineRepository());
            bool loop = true;
            int i=1;
            while (loop)
            {
            Console.WriteLine("----Order Viewing Interface----");
            Console.WriteLine("Order ID: "+toBeViewed.soNumber);
            Console.WriteLine("Destination Store ID: "+toBeViewed.soDestination);
            Console.WriteLine("Source Store ID: "+toBeViewed.soSource);
            Console.WriteLine("Date and Time: "+toBeViewed.soRequestTime);
            foreach (string item in toBeViewed.soLineItemNumbers)
            {
                LineItems _lineItem=_lineitemBL.GetItemByLine(item);
                Console.WriteLine(i+".  "+_lineItem.liGame+_lineItem.liSystem+"   "+_lineItem.liQuantity);
                i++;
            }
            i=1;
            Console.WriteLine("---------------------------");
            Console.WriteLine("Press enter to return to search menu");
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
        }
    }        

    private void FilterStockOrders()
    {
        string gameTarget="";
        string systemTarget="";
        bool loop = true;
            while (loop)
            {
            Console.WriteLine("----Order Filter Interface----");
            Console.WriteLine("Order Number: "+filter.soNumber);
            Console.WriteLine("Customer Number: "+filter.soDestination);
            Console.WriteLine("Store Number: "+filter.soSource);
            Console.WriteLine("Game: "+gameTarget);
            Console.WriteLine("Console: "+systemTarget);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[0] to remove filters and return to stock order search menu");
            Console.WriteLine("[1] to use the selected filters");
            Console.WriteLine("[2] to filter order number");
            Console.WriteLine("[3] to filter Customer Number");
            Console.WriteLine("[4] to filter Store Number");
            Console.WriteLine("[5] to filter by games within order");
            Console.WriteLine("[6] to filter by systems within order");
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
            switch (choice)
            {
                case "0":
                    noFilter=true;
                    loop=false;
                    filter=new StockOrders();
                    break;
                case "1":
                    loop=false;
                    readout=_orderBL.FilterStockOrder(filter,gameTarget,systemTarget);
                    Console.WriteLine("Filter Applied!  Press Enter to Continue");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Order Number:");
                    filter.soNumber=Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Customer Number:");
                    filter.soDestination=Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Store Number:");
                    filter.soSource=Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Product to search for:");
                    gameTarget=Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("Product to search for:");
                    systemTarget=Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("That input was not valid, please try again!");
                    break;
                }          
            }
        }
    }
}
