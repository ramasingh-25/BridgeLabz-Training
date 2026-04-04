using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    internal interface IAddressable
    {

        AddressBook FindBook(AddressBook[] books, String bookName);
        Contact[] FindByCity(AddressBook[] books, String searchCity);
        Contact[] FindByState(AddressBook[] books, String searchState);

        Contact FindByCityAndName(AddressBook[] books, String searchCity, String searchName);
        Contact FindByStateAndName(AddressBook[] books, String searchState, String searchName);

        int CountByCity(AddressBook[] books, String searchCity);
        int CountByState(AddressBook[] books, String searchState);
    }
}
