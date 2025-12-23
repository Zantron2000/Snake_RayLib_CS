using Raylib_cs;
using Snake.Model;

namespace Snake.View
{
    public class GridView : IView
    {
        private Grid grid;
        private Color evenColor;
        private Color oddColor;

        public GridView(Grid grid, Color evenColor, Color oddColor)
        {
            this.grid = grid;
            this.evenColor = evenColor;
            this.oddColor = oddColor;
        }

        public void Draw(int cellSize, int xOffset, int yOffset)
        {
            int rows = grid.GetRows();
            int columns = grid.GetColumns();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Color cellColor = (i + j) % 2 == 0 ? this.evenColor : this.oddColor;
                    Raylib.DrawRectangle(
                        xOffset + i * cellSize,
                        yOffset + j * cellSize,
                        cellSize,
                        cellSize,
                        cellColor
                    );
                }
            }
        }
    }
}