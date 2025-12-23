using Raylib_cs;
using Snake.Core;

namespace Snake.View
{
    public class SnakeView : IView
    {
        private Model.Snake snake;
        private Color color;

        public SnakeView(Model.Snake snake, Color color)
        {
            this.snake = snake;
            this.color = color;
        }

        public void Draw(int cellSize, int xOffset, int yOffset)
        {
            LinkedList<Vector2> positions = snake.GetPositions();

            foreach (Vector2 pos in positions)
            {
                Raylib.DrawRectangle(
                    xOffset + pos.X * cellSize,
                    yOffset + pos.Y * cellSize,
                    cellSize,
                    cellSize,
                    color
                );
            }
        }
    }
}