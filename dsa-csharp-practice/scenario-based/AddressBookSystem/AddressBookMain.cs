using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    internal class AddressBookMain
    {
     
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System");

            AddressBookMenu menu = new AddressBookMenu();
            menu.ShowMenu();
        }
    }

}

