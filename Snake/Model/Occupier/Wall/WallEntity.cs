using Snake.Core;

namespace Snake.Model.Occupier.Wall
{
    public class WallEntity : IOccupier
    {
        private readonly Vector2 position;

        public WallEntity(Vector2 position)
        {
            this.position = position;
        }

        public void Interact(Snake snake)
        {
            throw new Exception("Game Over");
        }

        public OccupierType GetOccupierType()
        {
            return OccupierType.Wall;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}