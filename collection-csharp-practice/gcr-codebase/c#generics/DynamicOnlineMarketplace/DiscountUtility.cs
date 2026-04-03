using System;

namespace BridgelabzCollection.DynamicOnlineMarketplace.Utilities
{
    public static class DiscountUtility
    {
        public static void ApplyDiscount<T>(T product, double percentage)
            where T : Product
        {
            double discountedPrice =
                product.Price - (product.Price * percentage / 100);

            product.UpdatePrice(discountedPrice);
        }
    }
}
