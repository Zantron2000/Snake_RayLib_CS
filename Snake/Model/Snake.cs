using Snake.Core;

namespace Snake.Model
{
    public class Snake
    {
        private readonly LinkedList<Vector2> segments;
        private readonly HashSet<Vector2> segmentSet;

        public int Size => segments.Count;

        public Snake(List<Vector2> initialPositions)
        {
            segments = new LinkedList<Vector2>();
            segmentSet = new HashSet<Vector2>();
            
            foreach (var position in initialPositions)
            {
                segments.AddLast(position);
                segmentSet.Add(position);
            }
        }

        public bool IsInPosition(Vector2 position)
        {
            return segmentSet.Contains(position);
        }

        public Vector2 GetHeadPosition()
        {
            return segments.First();
        }

        public Vector2 GetTailPosition()
        {
            return segments.Last();
        }

        public void Move(Vector2 newHeadPosition)
        {
            segments.AddFirst(newHeadPosition);
            segmentSet.Add(newHeadPosition);

            Vector2 tail = segments.Last();
            segments.RemoveLast();
            Vector2 newTail = segments.Last();

            if (!tail.Equals(newTail))
            {
                segmentSet.Remove(tail);
            }
        }

        public void Grow()
        {
            Vector2 tail = segments.Last();
            segments.AddLast(tail);
        }

        public LinkedList<Vector2> GetPositions()
        {
            return segments;
        }
    }
}