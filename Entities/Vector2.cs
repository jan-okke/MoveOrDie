using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Entities
{
    internal class Vector2
    {
        private int x, y;

        public int X { get => x; }
        public int Y { get => y; }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.X == right.X && left.Y == right.Y;
        }
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left.X == right.X && left.Y == right.Y);
        }
    }
}
