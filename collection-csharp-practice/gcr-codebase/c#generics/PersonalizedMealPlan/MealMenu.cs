using System;

namespace BridgelabzCollection.PersonalizedMealPlan
{
    public class MealMenu
    {
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Vegetarian");
                Console.WriteLine("2. Vegan");
                Console.WriteLine("3. Keto");
                Console.WriteLine("4. Exit");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (ch)
                {
                    case 1:
                        MealUtility.ShowMeal<VegetarianMeal>();
                        break;

                    case 2:
                        MealUtility.ShowMeal<VeganMeal>();
                        break;

                    case 3:
                        MealUtility.ShowMeal<KetoMeal>();
                        break;
                        case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
