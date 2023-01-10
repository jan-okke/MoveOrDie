using MoveOrDie.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Entities
{
    internal class Level : Map
    {
        public Level(int[][] data)
        {
            Size = new Vector2(data[0].Length, data.Length);
            int x = 0, y = 0;
            foreach (int[] array in data)
            {
                foreach (int d in array)
                {
                    Positions.Add(new Position(
                        new Vector2(x, y),
                        PositionStateExtension.GetFromNumber(d)
                    ));
                    x++;
                }
                y++;
            }
        }
        public Level(Vector2 size, List<Position> positions)
            : base(size, positions) { }
    }
}
