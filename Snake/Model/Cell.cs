using Snake.Core;
using Snake.Model.Occupier;

namespace Snake.Model
{
    public class Cell
    {
        private readonly Vector2 position;
        private IOccupier? occupier;

        public Cell(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public IOccupier? GetOccupier()
        {
            return occupier;
        }

        public void SetOccupier(IOccupier? occupier)
        {
            this.occupier = occupier;
        }

        public bool IsOccupied()
        {
            return occupier != null;
        }
    }
}