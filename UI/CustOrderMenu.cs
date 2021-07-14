using System;
using System.Collections.Generic;
using BL;
using Models;
using DL;

namespace UI
{
    public class CustOrderMenu : IMenu
    {

        private OrdersBL _ordersBL;
        private LineItemBL _lineitemBL;
        public string custom = "None Yet Selected";
        public string store=LoginMenu.storeID;
        public List<LineItems> lines = new List<LineItems>();
        public Orders order = new Orders();
        public string oNumber;
        private int i = 0;
        public int line = 1;
        public float subtotal=0;
        public float total=0;
        public CustOrderMenu(OrdersBL p_ordersBL, LineItemBL p_lineitemBL)
        {
            _ordersBL=p_ordersBL;
            _lineitemBL=p_lineitemBL;
        }
        public void Menu()
        {
            Console.WriteLine("----Welcome to the customer order menu!----");
            Console.WriteLine("[0] to return to the order menu");
            Console.WriteLine("[1] to place the order");
            Console.WriteLine("[2] to search for the customer placing the order: "+custom);
            Console.WriteLine("[3] to search for the store the customer is ordering from: "+store);
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
                _ordersBL.AddOrders(order);
                _lineitemBL.AddLineItems(lines);
                return MenuTitle.CustomerOrderMenu;
                case "2":
                CustSearchMenu.forOrder=true;
                CustSearchMenu run1 = new CustSearchMenu(new CustomerBL(new CustRepository()));
                custom=CustSearchMenu.result.cID;
                CustSearchMenu.forOrder=false;
                return MenuTitle.CustomerOrderMenu;
                case "3":
                LocSearchMenu.forOrder=true;
                LocSearchMenu run2 = new LocSearchMenu(new StoresBL(new StoreRepository()));
                store=LocSearchMenu.result.stNumber;
                LocSearchMenu.forOrder=false;
                return MenuTitle.CustomerOrderMenu;
                case "4":
                GameSearchMenu.forOrder=true;    
                GameSearchMenu run3 = new GameSearchMenu(new GamesBL(new GameRepository()));
                LineItems game = new LineItems();
                game.liGame=GameSearchMenu.result.gName;
                game=AssignDefaults(game);
                game.liPrice=GameSearchMenu.result.gMSRP;
                lines.Add(game);
                GameSearchMenu.forOrder=false;
                return MenuTitle.CustomerOrderMenu;
                case "5":
                SystemSearchMenu.forOrder=true;
                SystemSearchMenu run4 = new SystemSearchMenu(new SystemsBL(new SystemRepository()));
                LineItems console = new LineItems();
                console.liSystem=SystemSearchMenu.result.sName;
                console=AssignDefaults(console);
                console.liPrice=SystemSearchMenu.result.sMSRP;
                lines.Add(console);
                SystemSearchMenu.forOrder=false;
                return MenuTitle.CustomerOrderMenu;
                default:
                return MenuTitle.Error;
            }
        }
        public LineItems AssignDefaults(LineItems p_line)
        {
            order.oStoreNumber=store;
            order.oNumber="C"+(_ordersBL.FilterOrder(order).Count+1).ToString("000000000000");
            p_line.liOrderNumber=order.oNumber;
            p_line.liLineNumber=order.oNumber+line.ToString("000");
            line++;
            Console.WriteLine("Please enter quantity to order:");
            p_line.liQuantity=int.Parse(Console.ReadLine());
            return p_line;
        } 

        public Orders AssignOrderFields(Orders p_orders)
        {
            order.oCustomerNumber=custom;
            order.oDateAndTime=DateTime.Today;
            foreach (LineItems item in lines)
            {
                order.oLineItemNumbers.Add(item.liLineNumber);
            }
            return p_orders;
        }
    }
}