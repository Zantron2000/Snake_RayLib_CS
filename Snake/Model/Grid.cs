using Snake.Core;

namespace Snake.Model
{
    public class Grid
    {
        private readonly Cell[,] cells;
        private readonly HashSet<Vector2> unoccupiedPositions = new HashSet<Vector2>();
        
        public Grid (int rows, int columns)
        {
            cells = new Cell[rows, columns];
            unoccupiedPositions = new HashSet<Vector2>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    cells[r, c] = new Cell(new Vector2(c, r));
                    unoccupiedPositions.Add(new Vector2(c, r));
                }
            }
        }

        public void PlaceOccupier(Vector2 position, IOccupier occupier)
        {
            cells[position.Y, position.X].SetOccupier(occupier);
            unoccupiedPositions.Remove(position);
        }

        public void RemoveOccupierAtPosition(Vector2 position)
        {
            cells[position.Y, position.X].SetOccupier(null);
            unoccupiedPositions.Add(position);
        }

        public IOccupier? GetOccupierAtPosition(Vector2 position)
        {
            return cells[position.Y, position.X].GetOccupier();
        }

        public bool IsOutOfBounds(Vector2 position)
        {
            return position.X < 0 || position.X >= GetColumns() || position.Y < 0 || position.Y >= GetRows();
        }

        public int GetRows()
        {
            return cells.GetLength(0);
        }

        public int GetColumns()
        {
            return cells.GetLength(1);
        }

        public HashSet<Vector2> GetUnoccupiedPositions()
        {
            return unoccupiedPositions;
        }
    }
}