using MoveOrDie.Entities.Enums;
using MoveOrDie.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Entities
{
    internal class Map
    {
        protected Vector2 Size;
        protected List<Position> Positions;

        public Map()
        {
            Size = new Vector2(0, 0);
            Positions = new List<Position>();
        }
        public Map(Vector2 size, List<Position> positions)
        {
            Size = size;
            Positions = positions;
        }
        private void DrawAt(int x, int y)
        {
            foreach (Position p in Positions)
            {
                if (p.WorldPosition == new Vector2(x, y))
                {
                    Console.Write(p.State.AsString());
                }
            }
        }

        public void Draw()
        {
            for (int y = 0; y < Size.Y; y++)
            {
                for (int x = 0; x < Size.X; x++)
                {
                    DrawAt(x, y);
                }
                Console.WriteLine();
            }
        }
    }
}
