using Snake.Core;

namespace Snake.Model
{
    public interface IOccupier
    {
        public void Interact(Snake snake);

        public OccupierType GetOccupierType();

        public Vector2 GetPosition();
    }
}