using Snake.Core;

namespace Snake.Model
{
    public class Food : IFood
    {
        private static readonly OccupierType TYPE = OccupierType.Food;
        private readonly Vector2 position;
        public event EventHandler<IFood>? Eaten;

        public Food(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void Interact(Snake snake)
        {
            snake.Grow();

            Eaten?.Invoke(this, this);
        }

        public OccupierType GetOccupierType()
        {
            return TYPE;
        }

        public void RegisterSubscriber(IFoodSubscriber subscriber)
        {
            Eaten += (sender, food) => subscriber.OnFoodEaten(food);
        }
    }
}