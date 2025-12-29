using Snake.Core;
using Snake.Model.Occupier;

namespace Snake.View
{
    public class OccupierView : IView
    {
        private IOccupier occupier;

        public OccupierView(IOccupier occupier)
        {
            this.occupier = occupier;
        }

        public void Draw(int cellSize, int xOffset, int yOffset)
        {
            if (occupier.GetOccupierType() == OccupierType.Food)
            {
                Vector2 position = occupier.GetPosition();

                Raylib_cs.Raylib.DrawRectangle(
                    position.X * cellSize + xOffset,
                    position.Y * cellSize + yOffset,
                    cellSize,
                    cellSize,
                    Raylib_cs.Color.Red
                );
            }
        }
    }
}