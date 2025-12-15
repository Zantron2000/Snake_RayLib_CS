# Snake_RayLib_CS
The classic game SNAKE made using C# and the RayLib library
 
## Snake Class Diagram (Mermaid)

```mermaid
classDiagram
    Vector2 <.. IFoodGenerator : determines food positions with
    Vector2 <.. Direction : uses
    Vector2 <.. Snake : tracks positions with
    Vector2 <.. IOccupier : tracks position with
    Vector2 <.. Cell : tracks position with
    Vector2 <.. Grid : tracks cells and occupiers with
    Vector2 <.. Food : tracks position with
    Vector2 <.. OccupierPlacementStrategyBase : determines placement with
    Vector2 <.. DefaultFoodGenerator : processes food locations with
    Vector2 <.. OccupierView : draws occupiers at positions with
    Vector2 <.. SnakeView : draws snake at positions with
    Vector2 <.. Game : moves objects with
    OccupierType <.. IOccupier : classifies itself with
    OccupierType <.. Food : tracks occupier type with
    Snake <.. IOccupier : interacts with
    Snake <.. Food : interacts with
    Snake <.. FoodPlacementStrategy : determines snake locations with
    Snake <.. SmallMapSetupStrategy : creates
    Grid <.. FoodPlacementStrategy : determines occupier locations with
    Grid <.. SmallMapSetupStrategy : creates
    FoodPlacementStrategy <.. SmallMapSetupStrategy : creates
    IFood <.. IFoodSubscriber : subscribes to
    FoodQuantity <.. IGameSetupStrategy : determines settings with
    GameSettings <.. IGameSetupStrategy : builds
    IFoodSubscriber <.. IFoodGenerator : notifies food of
    IOccupierPlacementStrategy <.. DefaultFoodGenerator : determines food location with
    IFoodSpawnPolicy <.. DefaultFoodGenerator : determines amount of food to generate with
    IFood <.. DefaultFoodGenerator : returns created
    IFood <.. SmallMapSetupStrategy : creates initial
    IFood <.. Game : listens to 
    Food <.. DefaultFoodGenerator : creates
    GameSettings <.. GameSetupStrategyBase : generates
    GameSettings <.. SmallMapSetupStrategy : generates
    GameSettings <.. Game : initializes itself with
    DefaultFoodGenerator <.. SmallMapSetupStrategy : creates
    IOccupier <.. Game : sparks interacts between
    OccupierView <.. Game : creates and displays
    IGameSetupStrategy <.. Program : triggers
    SmallMapSetupStrategy <.. Program : creates

    Cell ..* Grid : made up of
    IView ..* Game : displays

    Vector2 --o SmallMapSetupStrategy : determines positions of others with
    IFoodSubscriber --o IFood : notifies
    IFood --o FoodGeneratorBase : holds
    IFood --o IFoodGenerator : produces
    FoodQuantity --o GameSetupStrategyBase : determines food spawn policy with
    FoodQuantity --o SmallMapSetupStrategy : determines food starting positions with
    IFoodSpawnPolicy --o GameSetupStrategyBase : holds

    IOccupier <-- Cell : holds up to one
    IOccupier <-- OccupierView : draws
    Snake <-- OccupierPlacementStrategyBase : holds
    Snake <-- SnakeView : draws
    Snake <-- Game : holds
    Grid <-- Game : holds
    Grid <-- OccupierPlacementStrategyBase : holds
    Grid <-- GridView : draws
    IFoodSpawnPolicy <-- FoodGeneratorBase : holds
    IOccupierPlacementStrategy <-- FoodGeneratorBase : holds
    IFoodGenerator <-- Game : holds
    Direction <-- Game : records
    GridView <-- Game : creates
    SnakeView <-- Game : creates
    Game <-- Program : starts

    IView <|-- GridView : implements
    IView <|-- OccupierView : implements
    IView <|-- SnakeView : implements
    IGameSetupStrategy <|-- GameSetupStrategyBase : implements
    IFoodSubscriber <|-- FoodGeneratorBase : implements
    IFoodSubscriber <|-- Game : implements
    IFoodGenerator <|-- FoodGeneratorBase : implements
    IOccupierPlacementStrategy <|-- OccupierPlacementStrategyBase : implements
    IFood <|-- Food : implements
    IOccupier <|-- IFood : implements
    IFoodSpawnPolicy <|-- StaticFoodSpawnPolicy : implements
    IFoodSpawnPolicy <|-- RandomFoodSpawnPolicy : implements
    StaticFoodSpawnPolicy <|-- ExplosionFoodSpawnPolicy : extends
    StaticFoodSpawnPolicy <|-- FiveFoodSpawnPolicy : extends
    StaticFoodSpawnPolicy <|-- ThreeFoodSpawnPolicy : extends
    StaticFoodSpawnPolicy <|-- OneFoodSpawnPolicy : extends
    StaticFoodSpawnPolicy <|-- TenFoodSpawnPolicy : extends
    OccupierPlacementStrategyBase <|-- FoodPlacementStrategy : extends
    FoodGeneratorBase <|-- DefaultFoodGenerator : extends
    GameSetupStrategyBase <|-- SmallMapSetupStrategy : extends

    class Direction {
        <<enumertion>>
        None
        Up
        Down
        Left
        Right
        + ToVector(Direction) Vector2$
        + IsOpposite(Direction, Direction) bool$
        + ToUnitVector(Direction) Vector2$
    }

    class FoodQuantity {
        <<enumeraation>>
        ONE
        THREE
        FIVE
        TEN
        RANDOM
        EXPLOSION
    }

    class GameSettings {
        + snake: Snake
        + grid: Grid
        + FoodGenerator: IFoodGenerator
        + WinningLength: int
    }

    class MapSize {
        <<enumeration>>
        Small
        Medium
        Large
    }

    class OccupierType {
        <<enumeration>>
        None
        Food
    }

    class Vector2 {
        + X : int
        + Y : int
        + Equals(object) bool
        + GetHashCode() int
        + plus(Vector2, Vector2) Vector2$
        + minus(Vector2, Vector2) Vector2$
    }

    class IFoodSpawnPolicy {
        <<interface>>
        + DetermineFoodToSpawn(int) int
    }
    
    class StaticFoodSpawnPolicy {
        <<abstract>>
        - maxFood: int
        + StaticFoodSpawnPolicy(int)
        + DetermineFoodToSpawn(int)
    }

    class ExplosionFoodSpawnPolicy {
        - MAX_FOOD: int$
    }

    class FiveFoodSpawnPolicy {
        - MAX_FOOD: int$
    }

    class ThreeFoodSpawnPolicy {
        - MAX_FOOD: int$
    }

    class TenFoodSpawnPolicy {
        - MAX_FOOD: int$
    }

    class OneFoodSpawnPolicy {
        - MAX_FOOD: int$
    }

    class RandomFoodSpawnPolicy {
        - maxFood: int
        - GenerateMaxFood() int$
        + RandomFoodSpawnPolicy()
        + DetermineFoodToSpawn(int) int
    }

    class Snake {
        - segments: LinkedList<Vector2>
        - segmentSet: HashSet<Vector2>
        + Size: int
        + Snake(List<Vector2>)
        + IsInPosition(Vector2) bool
        + GetHeadPosition() Vector2
        + GetTailPosition() Vector2
        + Move(Vector2) void
        + Grow() void
        + GetPositions() LinkedList<Vector2>
    }

    class IOccupier {
        <<interface>>
        + Interact(Snake) void
        + GetOccupierType() OccupierType
        + GetPosition() Vector2
    }

    class Cell {
        - position: Vector2
        - occupier: IOccupier?
        + Cell(Vector2)
        + GetPosition() Vector2
        + GetOccupier() IOccupier?
        + SetOccupier(IOccupier?) void
        + IsOccupied() bool
    }

    class Grid {
        - cells: Cell[,]
        - unoccupiedPositions: HashSet<Vector2>
        + Grid(int, int)
        + PlaceOccupier(Vector2, IOccupier) void
        + RemoveOccupierAtPosition(Vector2) void
        + GetOccupierAtPosition(Vector2) IOccupier?
        + IsOutOfBounds(Vector2) bool
        + GetRows() int
        + GetColumns() int
        + GetUnoccupiedPositions() Vector2
    }

    class IFood {
        <<interface>>
        + Eaten: EventHandler<IFood>
        + RegisterSubscriber(IFoodSubscriber) void
    }

    class IFoodSubscriber {
        <<interface>>
        + OnFoodEaten(IFood) void
    }

    class Food {
        - TYPE: OccupierType$
        - position: Vector2
        + Eaten: EventHandler<IFood>
        + Food(Vector2)
        + GetPosition() Vector2
        + Interact(Snake) void
        + GetOccupierType() OccupierType
        + RegisterSubscriber(IFoodSubscriber) void
    }

    class IOccupierPlacementStrategy {
        <<interface>>
        + FindPlacementPosition() Vector2?
    }

    class OccupierPlacementStrategyBase {
        <<abstract>>
        # Grid: Grid
        # Snake: Snake
        # OccupierPlacementStrategyBase(Grid, Snake)
        + FindPlacementPosition() Vector2*
    }

    class FoodPlacementStrategy {
        + FoodPlacementStrategy(Grid, Snake)
        + FindPlacementPosition() Vector2?
    }

    class IGameSetupStrategy {
        <<interface>>
        + CreateGameSettings(FoodQuantity) GameSettings
    }

    class IFoodGenerator {
        <<interface>>
        + GenerateFood(IFoodSubscriber) List<IFood>
        + DisableProduction() void
        + SubscribeAllFood(IFoodSubscriber) void
        + GenerateFoodAtPosition(List<Vector2>) List<IFood>
    }

    class FoodGeneratorBase {
        <<abstract>>
        - food: List<IFood>
        # ProduceFood: bool
        # SpawnPolicy: IFoodSpawnPolicy
        # FoodPlacement: IOccupierPlacementStrategy
        # DangerPlacement: IOccupierPlacementStrategy
        # FoodGeneratorBase(IOccupierPlacementStrategy, IOccupierPlacementStrategy, IFoodSpawnPolicy)
        # AddFood(IFood) void
        # GetFoodCount() int
        + DisableProduction() void
        + SubscribeAllFood(IFoodSubscriber) void
        + OnFoodEaten(IFood) void
        + GenerateFood(IFoodSubscriber) List<IFood>*
        + GenerateFoodAtPosition(List<Vector2>) List<IFood>*
    }

    class DefaultFoodGenerator {
        + DefaultFoodGenerator(IOccupierPlacementStrategy, IOccupierPlacementStrategy, IFoodSpawnPolicy)
        + GenerateFoodAtPositions(List<Vector2>) List<IFood>
        + GenerateFood(IFoodSubscriber) List<IFood>
    }

    class GameSetupStrategyBase {
        <<abstract>>
        # FOOD_POLICIES: Dictionary<FoodQuantity, IFoodSpawnPolicy>#
        + CreateGameSettings(FoodQuantity) GameSettings*
    }

    class SmallMapSetupStrategy {
        - GRID_ROWS: int#
        - GRID_COLUMNS: int#
        - SNAKE_STARTING_POSITIONS: List<Vector2>#
        - FOOD_STARTING_POSITIONS: Dictionary<FoodQuantity, List<Vector2>>#
        + CreateGameSettings(FoodQuantity) GameSettings
    }

    class IView {
        <<interface>>
        + Draw(int, int, int)
    }

    class GridView {
        - grid: Grid
        - evenColor: Color
        - oddColor: Color
        + GridView(Grid, Color, Color) void
        + Draw(int, int, int) void
    }

    class OccupierView {
        - occupier: IOccupier
        + OccupierView(IOccupier)
        + Draw(int, int, int) void
    }

    class SnakeView {
        - snake: Snake
        - color: Color
        + SnakeView(Snake, Color)
        + Draw(int, int, int)
    }

    class Game {
        - ODD_CELL_COLOR: Color#
        - EVEN_CELL_COLOR: Color#
        - snake: Snake
        - grid: Grid
        - foodGenerator: IFoodGenerator
        - views: List<IView>
        - currentDirection: Direction
        - winningLength: int
        - AssignDirection() void
        - MoveSnake() void
        + Game(GameSettings, Color)
        + OnFoodEaten(IFood) void
        + Update() void
        + Draw() void
    }

    class Program {
        - SCREEN_WIDTH: int#
        - SCREEN_HEIGHT: int#
    }
```
