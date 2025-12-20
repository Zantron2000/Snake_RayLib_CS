using Snake.Core;
using Snake.Model.FoodGenerator.FoodPolicy;
using Snake.Model.Placement;

namespace Snake.Model.FoodGenerator
{
    public class DefaultFoodGenerator : FoodGeneratorBase
    {
        public DefaultFoodGenerator(IOccupierPlacementStrategy foodPlacement, IOccupierPlacementStrategy dangerPlacement, IFoodSpawnPolicy spawnPolicy) : base(foodPlacement, dangerPlacement, spawnPolicy) {}

        public override List<IFood> GenerateFoodAtPositions(List<Vector2> positions)
        {
            List<IFood> generatedFood = new List<IFood>();

            foreach (var position in positions)
            {
                Food newFood = new Food(position);
                newFood.RegisterSubscriber(this);

                AddFood(newFood);
                generatedFood.Add(newFood);
            }

            return generatedFood;
        }

        public override List<IFood> GenerateFood(IFoodSubscriber subscriber)
        {
            List<IFood> generatedFood = new List<IFood>();
            int foodToMake = SpawnPolicy.DetermineFoodToSpawn(GetFoodCount());
            if (!ProduceFood)
            {
                return generatedFood;
            }

            for (int i = 0; i < foodToMake; i++)
            {
                Vector2? spawnPosition = FoodPlacement.FindPlacementPosition();
                if (spawnPosition.HasValue)
                {
                    Food newFood = new Food(spawnPosition.Value);
                    newFood.RegisterSubscriber(this);
                    newFood.RegisterSubscriber(subscriber);

                    AddFood(newFood);
                    generatedFood.Add(newFood);
                }
            }

            return generatedFood;
        }
    }
}