namespace BridgelabzCollection.PersonalizedMealPlan
{
    public class VegetarianMeal : IMealPlan
    {
        public string MealType()
        {
            return "Vegetarian";
        }

        public int GetCal()
        {
            return 1800;
        }
    }
}
