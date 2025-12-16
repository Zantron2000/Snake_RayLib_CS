namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public abstract class StaticFoodSpawnPolicy : IFoodSpawnPolicy
    {
        private readonly int maxFood;

        public StaticFoodSpawnPolicy(int maxFood)
        {
            this.maxFood = maxFood;
        }

        public int DetermineFoodToSpawn(int currentFoodCount)
        {
            if (currentFoodCount >= maxFood)
            {
                return 0;
            }

            return maxFood - currentFoodCount;
        }
    }
}