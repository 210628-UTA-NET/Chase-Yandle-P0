using System;
using System.Collections.Generic;
using BL;
using Models;
using DL;

namespace UI
{
    public class StockOrderMenu : IMenu
    {

        private StockOrdersBL _stockordersBL;
        private LineItemBL _lineitemBL;
        public string source;
        public string destination=LoginMenu.storeID;
        public List<LineItems> lines = new List<LineItems>();
        public StockOrders order = new StockOrders();
        public string oNumber;
        private int i = 0;
        public int line = 1;
        public float subtotal=0;
        public float total=0;
        public StockOrderMenu(StockOrdersBL p_stockordersBL, LineItemBL p_lineitemBL)
        {
            _stockordersBL=p_stockordersBL;
            _lineitemBL=p_lineitemBL;
        }
        public void Menu()
        {
            Console.WriteLine("----Welcome to the stock order menu!----");
            Console.WriteLine("[0] to return to the order menu");
            Console.WriteLine("[1] to place the order");
            Console.WriteLine("[2] to search for the store placing the order: "+destination);
            Console.WriteLine("[3] to search for the store the requestor is ordering from: "+source);
            Console.WriteLine("[4] to search for a game to add to the order");
            Console.WriteLine("[5] to search for a console to add to the order");
            foreach (LineItems item in lines)
            {
                Console.WriteLine(i+".  "+item.liGame+item.liSystem+"  "+item.liPrice+"  "+item.liQuantity+"   "+item.liPrice*item.liQuantity);
                i++;
                subtotal=subtotal+item.liPrice*item.liQuantity;
            }
            i=0;
            Console.WriteLine("Total: "+subtotal.ToString());
            total=subtotal;
            subtotal=0;
        }
        public MenuTitle UInput()
        {
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "0":
                return MenuTitle.OrderMenu;
                case "1":
                order=AssignOrderFields(order);
                _stockordersBL.AddStockOrders(order);
                return MenuTitle.StockOrderMenu;
                case "2":
                LocSearchMenu.forOrder=true;
                LocSearchMenu run1 = new LocSearchMenu(new StoresBL(new StoreRepository()));
                destination=LocSearchMenu.result.stNumber;
                LocSearchMenu.forOrder=false;
                return MenuTitle.StockOrderMenu;
                case "3":
                LocSearchMenu.forOrder=true;
                LocSearchMenu run2 = new LocSearchMenu(new StoresBL(new StoreRepository()));
                source=LocSearchMenu.result.stNumber;
                LocSearchMenu.forOrder=false;
                return MenuTitle.StockOrderMenu;
                case "4":
                GameSearchMenu.forOrder=true;    
                GameSearchMenu run3 = new GameSearchMenu(new GamesBL(new GameRepository()));
                LineItems game = new LineItems();
                game.liGame=GameSearchMenu.result.gName;
                game=AssignDefaults(game);
                game.liPrice=GameSearchMenu.result.gMSRP;
                lines.Add(game);
                GameSearchMenu.forOrder=false;
                return MenuTitle.StockOrderMenu;
                case "5":
                SystemSearchMenu.forOrder=true;
                SystemSearchMenu run4 = new SystemSearchMenu(new SystemsBL(new SystemRepository()));
                LineItems console = new LineItems();
                console.liSystem=SystemSearchMenu.result.sName;
                console=AssignDefaults(console);
                console.liPrice=SystemSearchMenu.result.sMSRP;
                lines.Add(console);
                SystemSearchMenu.forOrder=false;
                return MenuTitle.StockOrderMenu;
                default:
                return MenuTitle.Error;
            }
        }
        public LineItems AssignDefaults(LineItems p_line)
        {
            order.soSource=source;
            order.soNumber="S"+(_stockordersBL.FilterStockOrder(order).Count+1).ToString("000000000000");
            p_line.liOrderNumber=order.soNumber;
            p_line.liLineNumber=order.soNumber+line.ToString("000");
            line++;
            Console.WriteLine("Please enter quantity to order:");
            p_line.liQuantity=int.Parse(Console.ReadLine());
            return p_line;
        } 

        public StockOrders AssignOrderFields(StockOrders p_orders)
        {
            order.soDestination=destination;
            order.soRequestTime=DateTime.Today;
            foreach (LineItems item in lines)
            {
                order.soLineItemNumbers.Add(item.liLineNumber);
            }
            return p_orders;
        }
    }
}