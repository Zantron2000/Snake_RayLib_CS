using Snake.Core;

namespace Snake.Model.Placement
{
    public class FoodPlacementStrategy : OccupierPlacementStrategyBase
    {
        public FoodPlacementStrategy(Grid grid, Snake snake) : base(grid, snake) {}

        public override Vector2? FindPlacementPosition()
        {
            HashSet<Vector2> unoccupiedPositions = Grid.GetUnoccupiedPositions();
            LinkedList<Vector2> snakePositions = Snake.GetPositions();

            List<Vector2> possiblePositions = unoccupiedPositions.Except(snakePositions).ToList();
            if (possiblePositions.Count == 0)
            {
                return null;
            }

            Random rand = new Random();
            int index = rand.Next(0, possiblePositions.Count);
            return possiblePositions[index];
        }
    }
}