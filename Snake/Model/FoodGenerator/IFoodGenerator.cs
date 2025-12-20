using Snake.Core;

namespace Snake.Model.FoodGenerator
{
    public interface IFoodGenerator
    {
        public List<IFood> GenerateFood(IFoodSubscriber subscriber);
        public void DisableProduction();
        void SubscribeAllFood(IFoodSubscriber subscriber);
        List<IFood> GenerateFoodAtPositions(List<Vector2> position);
    }
}