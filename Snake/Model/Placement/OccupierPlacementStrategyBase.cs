using Snake.Core;

namespace Snake.Model.Placement
{
    public abstract class OccupierPlacementStrategyBase : IOccupierPlacementStrategy
    {
        protected Grid Grid { get; private set; }
        protected Snake Snake { get; private set; }

        protected OccupierPlacementStrategyBase(Grid grid, Snake snake)
        {
            this.Grid = grid;
            this.Snake = snake;
        }

        public abstract Vector2? FindPlacementPosition();
    }
}