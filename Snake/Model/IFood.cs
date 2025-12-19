namespace Snake.Model
{
    public interface IFood : IOccupier
    {
        event EventHandler<IFood> Eaten;

        void RegisterSubscriber(IFoodSubscriber subscriber);
    }
}