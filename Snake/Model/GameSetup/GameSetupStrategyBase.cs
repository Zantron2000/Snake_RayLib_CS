

using Snake.Core;
using Snake.Model.FoodGenerator.FoodPolicy;

namespace Snake.Model.GameSetup
{
    public abstract class GameSetupStrategyBase : IGameSetupStrategy
    {
        protected static readonly Dictionary<FoodQuantity, IFoodSpawnPolicy> FOOD_POLICIES = new()
        {
            { FoodQuantity.ONE, new OneFoodSpawnPolicy() },
            { FoodQuantity.THREE, new ThreeFoodSpawnPolicy() },
            { FoodQuantity.FIVE, new FiveFoodSpawnPolicy() },
            { FoodQuantity.TEN, new TenFoodSpawnPolicy() },
            { FoodQuantity.RANDOM, new RandomFoodSpawnPolicy() },
            { FoodQuantity.EXPLOSION, new ExplosionFoodSpawnPolicy() },
        };

        public abstract GameSettings CreateGameSettings(FoodQuantity foodQuantity);
    }
}