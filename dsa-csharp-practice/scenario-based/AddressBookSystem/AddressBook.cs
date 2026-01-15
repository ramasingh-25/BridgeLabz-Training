using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    internal class AddressBook
    {
        public static void Main (string[] args)
        {

            Console.WriteLine("Welcome to address book System");

            Contact cont = new Contact ();

            cont.ShowContact();

        }
       

    }
}
