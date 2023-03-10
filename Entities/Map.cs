using MoveOrDie.Entities.Enums;
using MoveOrDie.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Entities
{
    internal class Map
    {
        public bool GameOver = false;
        public bool MapComplete = false;
        protected Vector2 Size;
        protected Position[,] Positions;
        protected Vector2? PlayerPosition;
        protected Vector2 PlayerPositionInitial;
        protected int Actions = 0;
        protected TimeSpan Record = new TimeSpan();

        public Map()
        {
            Size = new Vector2(0, 0);
            Positions = new Position[0, 0];
            PlayerPosition = null;
        }
        protected void Init(Vector2 size, List<Position> positions, Vector2 playerPos)
        {
            Size = size;
            Positions = new Position[Size.X, Size.Y];
            for (int i = 0; i < positions.Count; i++)
            {
                Positions[i % size.X, i / size.X] = positions[i];
            }
            PlayerPositionInitial = new Vector2(playerPos.X, playerPos.Y);
            PlayerPosition = playerPos;
        }
        public Map(Vector2 size, List<Position> positions, Vector2 playerPos)
        {
            Init(size, positions, playerPos);
        }
        public void Draw(TimeSpan gameTime)
        {
            if (PlayerPosition is null) return;
            Console.Write($"Time: {gameTime} Turns: {Actions}");
            if (Actions > 0) Console.Write($" Average Turn Time: {gameTime / Actions}");
            Console.WriteLine();
            if (Record.TotalMilliseconds > 0) Console.WriteLine($"Record: {Record}");
            for (int y = 0; y < Size.Y; y++)
            {
                for (int x = 0; x < Size.X; x++)
                {
                    if (PlayerPosition.X == x && PlayerPosition.Y == y)
                        Console.Write(PositionState.Player.AsString());
                    else
                        Console.Write(Positions[x, y].State.AsString());
                }
                Console.WriteLine();
            }
        }

        private bool CheckCanMoveToPosition(Vector2 position)
        {
            var state = Positions[position.X, position.Y].State;
            if (state == PositionState.Enemy) GameOver = true;
            if (state == PositionState.Goal) MapComplete = true;
            return state != PositionState.Obstacle;
        }

        public void Move(Direction direction)
        {
            if (PlayerPosition is null) throw new Exception("Player Position was null");
            Actions++;
            switch (direction)
            {
                case Direction.Left:
                    if (CheckCanMoveToPosition(new Vector2(PlayerPosition.X-1, PlayerPosition.Y)))
                    {
                        PlayerPosition.X--;
                    }
                    break;
                case Direction.Right:
                    if (CheckCanMoveToPosition(new Vector2(PlayerPosition.X + 1, PlayerPosition.Y)))
                    {
                        PlayerPosition.X++;
                    }
                    break;
                case Direction.Up:
                    if (CheckCanMoveToPosition(new Vector2(PlayerPosition.X, PlayerPosition.Y - 1)))
                    {
                        PlayerPosition.Y--;
                    }
                    break;
                case Direction.Down:
                    if (CheckCanMoveToPosition(new Vector2(PlayerPosition.X, PlayerPosition.Y + 1)))
                    {
                        PlayerPosition.Y++;
                    }
                    break;
            }
        }
    }
}
