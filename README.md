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
```
