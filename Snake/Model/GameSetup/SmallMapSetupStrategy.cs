using Snake.Core;
using Snake.Model.FoodGenerator;
using Snake.Model.Placement;

namespace Snake.Model.GameSetup
{
    public class SmallMapSetupStrategy : GameSetupStrategyBase
    {
        private static readonly int GRID_ROWS = 9;
        private static readonly int GRID_COLUMNS = 10;
        private static readonly List<Vector2> SNAKE_STARTING_POSITIONS = new()
        {
            new(3, 4),
            new(2, 4),
            new(1, 4),
            new(0, 4),
        };
        private static readonly Dictionary<FoodQuantity, List<Vector2>> FOOD_STARTING_POSITIONS = new()
        {
            { FoodQuantity.ONE, new List<Vector2> { new(7, 4) } },
            { FoodQuantity.THREE, new List<Vector2> { new(7, 4), new(5, 2), new(5, 6) } },
            { FoodQuantity.FIVE, new List<Vector2> { new(4, 2), new(4, 6), new(6, 4), new(8, 2), new(8, 6) } },
            { FoodQuantity.TEN, new List<Vector2> { new(1, 0), new(1, 8), new(3, 2), new(3, 6), new(5, 0), new(5, 4), new(5, 8), new(7, 2), new(7, 6), new(9, 4) } },
            { FoodQuantity.RANDOM, new List<Vector2>{ new(7, 4) } },
            { FoodQuantity.EXPLOSION, new List<Vector2> { new(7, 4) } },
        };

        public override GameSettings CreateGameSettings(FoodQuantity foodQuantity)
        {
            Snake snake = new Snake(SNAKE_STARTING_POSITIONS);
            Grid grid = new Grid(GRID_ROWS, GRID_COLUMNS);

            FoodPlacementStrategy foodPlacementStrategy = new FoodPlacementStrategy(grid, snake);

            DefaultFoodGenerator foodGenerator = new DefaultFoodGenerator(
                foodPlacementStrategy,
                foodPlacementStrategy,
                FOOD_POLICIES[foodQuantity]
            );
            int winningLength = GRID_ROWS * GRID_COLUMNS;

            List<Vector2> foodPositions = FOOD_STARTING_POSITIONS[foodQuantity];
            List<IFood> foods = foodGenerator.GenerateFoodAtPositions(foodPositions);
            foods.ForEach(food => grid.PlaceOccupier(food.GetPosition(), food));

            return new GameSettings(snake, grid, foodGenerator, winningLength);
        }
    }
}