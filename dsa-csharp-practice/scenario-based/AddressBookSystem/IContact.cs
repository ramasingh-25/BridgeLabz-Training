using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    internal interface IContact
    {

        void AddContact();
        void EditContactByName();
        void DeleteContact();

        void SearchByCityOrState();   // UC-7
        void DisplayContact();
    }

    }

