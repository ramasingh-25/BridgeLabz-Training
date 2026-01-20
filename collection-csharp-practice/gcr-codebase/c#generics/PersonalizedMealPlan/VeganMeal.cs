namespace BridgelabzCollection.PersonalizedMealPlan
{
    public class VeganMeal : IMealPlan
    {
        public string MealType()
        {
            return "Vegan";
        }

        public int GetCal()
        {
            return 1600;
        }
    }
}
