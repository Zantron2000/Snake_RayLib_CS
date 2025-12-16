namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public class OneFoodSpawnPolicy : StaticFoodSpawnPolicy
    {
        private static readonly int MAX_FOOD = 1;
        public OneFoodSpawnPolicy() : base(MAX_FOOD) {}
    }
}