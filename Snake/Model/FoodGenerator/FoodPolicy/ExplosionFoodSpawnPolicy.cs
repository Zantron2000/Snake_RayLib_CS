namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public class ExplosionFoodSpawnPolicy : StaticFoodSpawnPolicy
    {
        private static readonly int MAX_FOOD = 24;

        public ExplosionFoodSpawnPolicy() : base(MAX_FOOD) {}
    }
}