namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public class RandomFoodSpawnPolicy : IFoodSpawnPolicy
    {
        private int maxFood;

        private static int GenerateMaxFood()
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        }

        public RandomFoodSpawnPolicy()
        {
            maxFood = GenerateMaxFood();
        }

        public int DetermineFoodToSpawn(int currentFoodCount)
        {
            if (currentFoodCount == 0)
            {
                maxFood = GenerateMaxFood();
                return maxFood;
            }

            return 0;
        }
    }
}