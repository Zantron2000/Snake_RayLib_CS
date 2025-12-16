namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public class ThreeFoodSpawnPolicy : StaticFoodSpawnPolicy
    {
        private static readonly int MAX_FOOD = 3;
        public ThreeFoodSpawnPolicy() : base(MAX_FOOD) {}
    }
}