using System;
using Models;
using System.Collections.Generic;
using BL;
using DL;
using System.Threading;

namespace UI
{
    public class LocSearchMenu : IMenu
    {
        public static Stores result = new Stores();
        private Stores filter = new Stores();
        public static bool forOrder = false;
        List<Stores> readout = new List<Stores>();
        private StoresBL _storeBL;
        public bool noFilter = true;
        private Systems cSystems = new Systems(); 
        public LocSearchMenu(StoresBL p_storeBL)
        {
            _storeBL=p_storeBL;
        }
        public void Menu()
        {
            if (noFilter)
            {
                readout=_storeBL.GetAllStores();
                Console.WriteLine("----Store Search / Edit Menu----");
                Console.WriteLine("[0] to return to the search menu");
                Console.WriteLine("[1] to retrieve all stores ("+readout.Count+")");
                Console.WriteLine("[2] to apply search filters");
            } else
            {
                Console.WriteLine("----Store Search / Edit Menu----");
                Console.WriteLine("[0] to return to the search menu");
                Console.WriteLine("[1] to retrieve filtered list of stores ("+readout.Count+")");
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
                return MenuTitle.SearchMenu;
                case "1":
                StoreList(readout);
                return MenuTitle.LocationSearchMenu;
                case "2":
                FilterStore();
                noFilter=false;
                return MenuTitle.LocationSearchMenu;
                case "3":
                if (noFilter)
                {
                    return MenuTitle.Error;
                } else
                {
                    noFilter=true;
                    return MenuTitle.LocationSearchMenu;
                }
                default:
                return MenuTitle.Error;
            }
        }
        public void StoreList(List<Stores> reading)
        {
            Console.Clear();
            int i = 1;
            Console.WriteLine("Store List");
            foreach (Stores store in reading)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine(i+".  Store#: "+store.stNumber +" | Phone: "+ store.stPhone +" | Email: "+ store.stEmail);
                Console.WriteLine("=======================================");
                i++;
            }
            Console.WriteLine("End of list");
            Console.WriteLine("Enter 0 to return to search menu");
            if (!forOrder)
            {
                Console.WriteLine("Enter the number of the store that you would like to edit");
            } else
            {
                Console.WriteLine("Enter the number of the store that is being used in this order");
            }
            int choice = int.Parse(Console.ReadLine());
            if (choice==0)
            {
                Console.WriteLine("Returning to store search menu");
            } else if (choice<=reading.Count)
            {
                if (!forOrder)
                {
                    EditStore(reading[(choice-1)]);
                } else
                {
                    result = reading[(choice-1)];
                }
                
            } else
            {
                Console.WriteLine("That input was not valid, please try again!");
            }
        }

        public void EditStore(Stores toBeChanged)
        {
            bool loop = true;
            while (loop)
            {
            Console.WriteLine("----Store Edit Interface----");
            Console.WriteLine("Store ID: "+toBeChanged.stNumber);
            Console.WriteLine("Address: "+toBeChanged.stStreet+" "+toBeChanged.stCity+", "+toBeChanged.stState);
            Console.WriteLine("Phone Number: "+toBeChanged.stPhone);
            Console.WriteLine("Email: "+toBeChanged.stEmail);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[0] to return to search menu");
            Console.WriteLine("[1] to submit store changes to database");
            Console.WriteLine("[2] to edit store address");
            Console.WriteLine("[3] to edit store phone number");
            Console.WriteLine("[4] to edit store email");
            Console.WriteLine("[5] to view this store's Inventory");
            Console.WriteLine("[6] to remove store data from database (Store ID will remain)");
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
            switch (choice)
            {
                case "0":
                    loop = false;
                    break;
                case "1":
                    loop=false;
                    _storeBL.EditStore(toBeChanged);
                    Console.WriteLine("Store "+toBeChanged.stNumber+" Edited!  Press Enter to Continue");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Street:");
                    toBeChanged.stStreet=Console.ReadLine();
                    Console.WriteLine("City:");
                    toBeChanged.stCity=Console.ReadLine();
                    Console.WriteLine("State:");
                    toBeChanged.stState=Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Phone Number:");
                    toBeChanged.stPhone=Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Email:");
                    toBeChanged.stEmail=Console.ReadLine();
                    break;
                case "5":
                    List<LineItems> inventory = new List<LineItems>();
                    inventory=_storeBL.GamesAtEachLocation(toBeChanged);
                    foreach (LineItems item in inventory)
                    {
                        Console.WriteLine(item.liGame+item.liSystem+": "+item.liQuantity);
                    }
                    Console.WriteLine("Press Enter to proceed");
                    Console.ReadLine();
                    break;
                case "6":
                    Console.WriteLine("WARNING! You have chosen to delete this store from the database");
                    Console.WriteLine("To confirm this decision please enter the following word: Delete");
                    if (Console.ReadLine()=="Delete")
                    {
                        _storeBL.DeleteStore(toBeChanged);
                        Console.WriteLine("Store "+toBeChanged.stNumber+" removed from the database");
                    }   else
                    {
                        Console.WriteLine("Store "+toBeChanged.stNumber+" not removed from the database");
                    }
                    break;
                default:
                    Console.WriteLine("That input was not valid, please try again!");
                    break;
            }          
        }
    }        
    private void FilterStore()
    {
        bool loop = true;
            while (loop)
            {
            Console.WriteLine("----Store Filter Interface----");
            Console.WriteLine("Store ID: "+filter.stNumber);
            Console.WriteLine("Address: "+filter.stStreet+" "+filter.stCity+", "+filter.stState);
            Console.WriteLine("Phone Number: "+filter.stPhone);
            Console.WriteLine("Email: "+filter.stEmail);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[0] to remove filters and return to store search menu");
            Console.WriteLine("[1] to use the selected filters");
            Console.WriteLine("[2] to filter store ID");
            Console.WriteLine("[3] to filter store address");
            Console.WriteLine("[4] to filter store phone number");
            Console.WriteLine("[5] to filter store email");
            string choice = Console.ReadLine();
            Console.WriteLine("--------------------");
            switch (choice)
            {
                case "0":
                    noFilter=true;
                    loop=false;
                    filter=new Stores();
                    break;
                case "1":
                    loop=false;
                    readout=_storeBL.FilterStore(filter);
                    Console.WriteLine("Filter Applied!  Press Enter to Continue");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Store ID:");
                    filter.stNumber=Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Street:");
                    filter.stStreet=Console.ReadLine();
                    Console.WriteLine("City:");
                    filter.stCity=Console.ReadLine();
                    Console.WriteLine("State:");
                    filter.stState=Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Phone Number:");
                    filter.stPhone=Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Email:");
                    filter.stEmail=Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("That input was not valid, please try again!");
                    break;
                }          
            }
        }
    }
}
