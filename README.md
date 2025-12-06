# Snake_RayLib_CS
The classic game SNAKE made using C# and the RayLib library
 
## Snake Class Diagram (Mermaid)

```mermaid
classDiagram
	class Snake {
		- positions: Queue<Vector2>
        - CheckSelfCollision(): bool
        + Snake(initialPosition: Vector2, initialLength: int)
        + GetHeadPosition(): Vector2
        + GetPositions(): Queue<Vector2>
        + Move(space: Vector2): void
        + Grow(): void
	}

    interface Occupier {
        + Interact(snake: Snake): void
    }

    class Food implements Occupier {
        - position: Vector2
        + Food(position: Vector2)
        + GetPosition(): Vector2
        + Interact(snake: Snake): void
    }

    class Cell {
        - position: Vector2
        - occupier: Occupier
        + Cell(position: Vector2)
        + GetPosition(): Vector2
        + GetOccupier(): Occupier
        + SetOccupier(occupier: Occupier): void
        + IsOccupied(): bool
    }
```
