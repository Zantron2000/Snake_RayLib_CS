using Snake.Model;
using Snake.Model.FoodGenerator;

namespace Snake.Core
{
    public class GameSettings
    {
        public Model.Snake Snake { get; private set; }
        public Grid Grid { get; private set; }
        public IFoodGenerator FoodGenerator { get; private set; }
        public int WinningLength { get; private set; }

        public GameSettings(Model.Snake snake, Grid grid, IFoodGenerator foodGenerator, int winningLength)
        {
            Snake = snake;
            Grid = grid;
            FoodGenerator = foodGenerator;
            WinningLength = winningLength;
        }
    }
}