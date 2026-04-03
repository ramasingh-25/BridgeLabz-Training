namespace BridgelabzCollection.PersonalizedMealPlan
{
    public class KetoMeal : IMealPlan
    {
        public string MealType()
        {
            return "Keto";
        }

        public int GetCal()
        {
            return 2000;
        }
    }
}
