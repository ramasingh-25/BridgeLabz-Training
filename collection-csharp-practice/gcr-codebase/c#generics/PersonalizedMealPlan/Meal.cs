using System;

namespace BridgelabzCollection.PersonalizedMealPlan
{
    public class Meal<T> where T : IMealPlan, new()
    {
        public T Generate()
        {
            return new T();
        }
    }
}
