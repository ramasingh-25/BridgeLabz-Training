using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.AddressBookSystem
{
    using System;

   
        public class AddressBook
        {
            public String bookName { get; set; }
            public Contact[] contacts { get; set; }

            public AddressBook(String bookName)
            {
                this.bookName = bookName;
                this.contacts = new Contact[1000];
            }
        }
    }