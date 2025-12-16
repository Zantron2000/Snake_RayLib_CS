using Snake.Core;

namespace Snake.Model.FoodGenerator.FoodPolicy
{
    public interface IFoodSpawnPolicy
    {
        public int DetermineFoodToSpawn(int currentFoodCount);
    }
}