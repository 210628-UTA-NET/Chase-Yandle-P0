using System;
using Models;
using System.Collections.Generic;
using BL;
using DL;
using System.Threading;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using DL.Entities;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            string connectionString = configuration.GetConnectionString("Reference2DB");
            DbContextOptions<DemoDbContext> options = new DbContextOptionsBuilder<DemoDbContext>()
            .UseSqlServer(connectionString)
            .Options;
            SplashScreen.SplashMessage();
            Thread.Sleep(2000);
            Console.Clear();
            LoginMenu.Login();
            IMenu newMenu = new MainMenu();
            bool loop = true;
            MenuTitle location = MenuTitle.MainMenu;
            while(loop)
            {
                Console.Clear();
                newMenu.Menu();
                location = newMenu.UInput();

                switch(location)
                {
                    case MenuTitle.MainMenu:
                    newMenu = new MainMenu();
                    break;
                    case MenuTitle.CustomerAddMenu:
                    newMenu = new CustAddMenu(new CustomerBL(new CustRepository()));
                    break;
                    case MenuTitle.CustomerSearchMenu:
                    CustSearchMenu.forOrder=false;
                    newMenu = new CustSearchMenu(new CustomerBL(new CustRepository()));
                    break;
                    case MenuTitle.LoginMenu:
                    LoginMenu.Login();
                    newMenu = new MainMenu();
                    break;
                    case MenuTitle.Exit:
                    Console.Clear();
                    SplashScreen.SplashMessage();
                    Console.WriteLine("Thank you for using this program!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    loop=false;
                    break;
                    case MenuTitle.AddMenu:
                    newMenu = new AddMenu();
                    break;
                    case MenuTitle.SearchMenu:
                    newMenu = new SearchMenu();
                    break;
                    case MenuTitle.OrderMenu:
                    newMenu = new OrderMenu();
                    break;
                    case MenuTitle.LocationAddMenu:
                    newMenu = new LocAddMenu(new StoresBL(new StoreRepository()));
                    break;
                    case MenuTitle.LocationSearchMenu:
                    newMenu = new LocSearchMenu(new StoresBL(new StoreRepository()));
                    break;
                    case MenuTitle.ProductSearchMenu:
                    newMenu = new ProdSelect();
                    break;
                    case MenuTitle.GameSearchMenu:
                    newMenu = new GameSearchMenu(new GamesBL(new GameRepository()));
                    break;
                    case MenuTitle.SystemSearchMenu:
                    newMenu = new SystemSearchMenu(new SystemsBL(new SystemRepository()));
                    break;
                    case MenuTitle.StockOrderSearchMenu:
                    newMenu = new StockOrdSearchMenu(new StockOrdersBL(new StockOrdRepository()));
                    break;
                    case MenuTitle.CustomerOrderSearchMenu:
                    newMenu = new CustOrdSearchMenu(new OrdersBL(new OrdRepository()));
                    break;
                    case MenuTitle.CustomerOrderMenu:
                    newMenu = new CustOrderMenu(new OrdersBL(new OrdRepository()),new LineItemBL(new LineRepository()));
                    break;
                    case MenuTitle.StockOrderMenu:
                    newMenu = new StockOrderMenu(new StockOrdersBL(new StockOrdRepository()),new LineItemBL(new LineRepository()));   
                    break;                 
                    default:
                    Console.WriteLine("That input was not valid, please try again!");
                    break;
                    
                }
            }
        }
        public static string StringListOneLine(List<string> items)
        {
            return string.Join<string>(", ",items);
        }
    }
}
