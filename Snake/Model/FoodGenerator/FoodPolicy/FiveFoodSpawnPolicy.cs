namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public class FiveFoodSpawnPolicy : StaticFoodSpawnPolicy
    {
        private static readonly int MAX_FOOD = 5;
        public FiveFoodSpawnPolicy() : base(MAX_FOOD) {}
    }
}