using Snake.Core;

namespace Snake.Model.Placement
{
    public interface IOccupierPlacementStrategy
    {
        Vector2? FindPlacementPosition();
    }
}