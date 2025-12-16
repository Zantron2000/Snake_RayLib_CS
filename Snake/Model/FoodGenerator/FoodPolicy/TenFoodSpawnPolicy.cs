namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public class TenFoodSpawnPolicy : StaticFoodSpawnPolicy
    {
        private static readonly int MAX_FOOD = 10;
        public TenFoodSpawnPolicy() : base(MAX_FOOD) {}
    }
}