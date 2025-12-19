using Snake.Core;

namespace Snake.Model.GameSetup
{
    public interface IGameSetupStrategy
    {
        GameSettings CreateGameSettings(FoodQuantity foodQuantity);
    }
}