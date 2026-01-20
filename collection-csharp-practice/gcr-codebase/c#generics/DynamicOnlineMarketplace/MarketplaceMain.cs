using System;


namespace BridgelabzCollection.DynamicOnlineMarketplace
{
    class MarketplaceMain
    {
        static void Main()
        {
            MarketplaceMenu menu = new MarketplaceMenu();
            menu.Start();   // changed from ShowMenu()

            Console.ReadLine();
        }
    }
}
