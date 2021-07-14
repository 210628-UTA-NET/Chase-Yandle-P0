using System;
using Models;
using System.Globalization;
using BL;
using DL;
using System.Collections.Generic;

namespace UI
{
    public class LoginMenu
    {
        public static string storeID="0000";
        public static Stores hub = new Stores();
        public static int customersAddedFrom;
        public static void Login()
        {
            Console.WriteLine("----Welcome to the Gameshop Storefront Application----");
            Console.WriteLine("Please enter the store number or enter 0 for a list of storefronts:");
            string selection = Console.ReadLine();
            if (selection=="0")
            {
                Console.WriteLine("[0] Will use store 0000 (The Void)");
                selection=StoreList();
            } else
            {
                StoresBL store = new StoresBL(new StoreRepository());
                storeID=selection;
                hub=store.GetStoreByNumber(storeID);
                customersAddedFrom = store.CountCustomers(hub);
            }
        }

        private static string StoreList()
        {
            int i = 0;
            List<Stores> storeList = new List<Stores>();
            foreach (Stores item in storeList)
            {
                Console.WriteLine("["+i+"]  Store: "+item.stNumber+"   City: "+item.stCity);
                i++;
            }
            Console.WriteLine("Please enter the number of the store you would like to use");
            int choice = int.Parse(Console.ReadLine());
            if (choice>0 && choice<=storeList.Count)
            {
                return storeList[choice-1].stNumber;
            }
            else
            {
                return "0001";
            }
        }
    }
}