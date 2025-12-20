namespace Snake.Model
{
    public interface IFoodSubscriber
    {
        void OnFoodEaten(IFood food);
    }
}