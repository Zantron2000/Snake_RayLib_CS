using Snake.Core;

namespace Snake.Model.Occupier
{
    public interface IOccupier
    {
        public void Interact(Snake snake);

        public OccupierType GetOccupierType();

        public Vector2 GetPosition();
    }
}