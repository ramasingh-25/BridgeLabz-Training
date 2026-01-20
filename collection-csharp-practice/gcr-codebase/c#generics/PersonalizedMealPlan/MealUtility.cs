namespace BridgelabzCollection.PersonalizedMealPlan
{
    public class MealUtility
    {
        public static void ShowMeal<T>() where T : IMealPlan, new()
        {
            Meal<T> meal = new Meal<T>();
            T plan = meal.Generate();

            Console.WriteLine("Meal Type : " + plan.MealType());
            Console.WriteLine("Calories  : " + plan.GetCal());
        }
    }
}
