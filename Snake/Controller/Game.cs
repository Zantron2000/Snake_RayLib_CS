using Snake.Model;
using Snake.Model.FoodGenerator;
using Snake.Model.Occupier;
using Snake.View;
using Snake.Core;
using Raylib_cs;

namespace Snake.Controller
{
    public class Game : IFoodSubscriber
    {
        private static readonly Color ODD_CELL_COLOR = new(0xb0, 0xd4, 0x59);
        private static readonly Color EVEN_CELL_COLOR = new(0xa8, 0xce, 0x52);

        private readonly Model.Snake snake;
        private readonly Grid grid;
        private readonly IFoodGenerator foodGenerator;
        private readonly List<IView> views;
        private Direction currentDirection;
        private readonly int winningLength;

        private void AssignDirection()
        {
            Direction pressedDirection = currentDirection;
            if (Raylib.IsKeyPressed(KeyboardKey.Up))
            {
                pressedDirection = Direction.Up;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Down))
            {
                pressedDirection = Direction.Down;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Left))
            {
                pressedDirection = Direction.Left;
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.Right))
            {
                pressedDirection = Direction.Right;
            }

            if (!pressedDirection.IsOpposite(currentDirection))
            {
                currentDirection = pressedDirection;
            }
        }

        private void MoveSnake()
        {
            if (currentDirection == Direction.None)
            {
                return;
            }
            Vector2 movementVector = currentDirection.ToUnitVector2();
            Vector2 headPosition = snake.GetHeadPosition();
            Vector2 newHeadPosition = headPosition + movementVector;

            if (grid.IsOutOfBounds(newHeadPosition) || snake.IsInPosition(newHeadPosition) && !newHeadPosition.Equals(snake.GetTailPosition()))
            {
                throw new Exception("Game Over");
            } 
            else if (grid.GetOccupierAtPosition(newHeadPosition) != null)
            {
                snake.Move(newHeadPosition);

                IOccupier? occupier = grid.GetOccupierAtPosition(newHeadPosition);
                occupier?.Interact(snake);
            }
            else 
            {
                snake.Move(newHeadPosition);
            }
        }

        public Game(GameSettings settings, Color snakeColor)
        {
            snake = settings.Snake;
            grid = settings.Grid;
            currentDirection = Direction.None;
            foodGenerator = settings.FoodGenerator;
            winningLength = settings.WinningLength;
            views = new List<IView>
            {
                new GridView(grid, EVEN_CELL_COLOR, ODD_CELL_COLOR),
                new SnakeView(snake, snakeColor),
            };

            foodGenerator.SubscribeAllFood(this);     
        }

        public void OnFoodEaten(IFood food)
        {
            Vector2 foodPosition = food.GetPosition();
            grid.RemoveOccupierAtPosition(foodPosition);

            List<IFood> newFood = foodGenerator.GenerateFood(this);
            newFood.ForEach(f => grid.PlaceOccupier(f.GetPosition(), f));
        }

        public void Update()
        {
            AssignDirection();
            MoveSnake();

            if (snake.Size >= winningLength)
            {
                throw new Exception("You Win!");
            }
        }

        public void Draw()
        {
            int cellSize = 40;
            int xOffset = Raylib.GetScreenWidth() / 2 - grid.GetColumns() * cellSize / 2;
            int yOffset = Raylib.GetScreenHeight() / 2 - grid.GetRows() * cellSize / 2;

            foreach (IView view in views)
            {
                view.Draw(cellSize, xOffset, yOffset);
            }

            for (int i = 0; i < grid.GetRows(); i++)
            {
                for (int j = 0; j < grid.GetColumns(); j++)
                {
                    var occupier = grid.GetOccupierAtPosition(new Vector2(j, i));
                    if (occupier != null)
                    {
                        OccupierView occupierView = new OccupierView(occupier);
                        occupierView.Draw(cellSize, xOffset, yOffset);
                    }
                }
            }
        }
    }
}