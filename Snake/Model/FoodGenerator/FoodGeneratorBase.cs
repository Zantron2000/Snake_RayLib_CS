using Snake.Core;
using Snake.Model.FoodGenerator.FoodPolicy;
using Snake.Model.Placement;

namespace Snake.Model.FoodGenerator
{
    public abstract class FoodGeneratorBase : IFoodGenerator, IFoodSubscriber
    {
        private readonly List<IFood> food;
        protected bool ProduceFood { get; private set; }
        protected IFoodSpawnPolicy SpawnPolicy { get; private set; }
        protected IOccupierPlacementStrategy FoodPlacement { get; private set; }
        protected IOccupierPlacementStrategy DangerPlacement { get; private set; }

        protected FoodGeneratorBase(IOccupierPlacementStrategy foodPlacement, IOccupierPlacementStrategy dangerPlacement, IFoodSpawnPolicy spawnPolicy)
        {
            ProduceFood = true;
            food = new List<IFood>();
            SpawnPolicy = spawnPolicy;
            FoodPlacement = foodPlacement;
            DangerPlacement = dangerPlacement;
        }

        protected void AddFood(IFood newFood)
        {
            food.Add(newFood);
        }

        protected int GetFoodCount()
        {
            return food.Count;
        }

        public void DisableProduction()
        {
            ProduceFood = false;
        }

        public void SubscribeAllFood(IFoodSubscriber subscriber)
        {
            foreach (var f in food)
            {
                f.RegisterSubscriber(subscriber);
            }
        }

        public void OnFoodEaten(IFood food)
        {
            this.food.Remove(food);
        }

        public abstract List<IFood> GenerateFood(IFoodSubscriber subscriber);

        public abstract List<IFood> GenerateFoodAtPositions(List<Vector2> position);
    }
}