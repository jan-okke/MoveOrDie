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
        public bool Unlocked;
        public string Name;
        public Level(string name, int[][] data, Vector2 playerPos)
        {
            Name = name;
            List<Position> pos = new();
            Size = new Vector2(data[0].Length, data.Length);
            int x = 0, y = 0;
            foreach (int[] array in data)
            {
                foreach (int d in array)
                {
                    pos.Add (new Position(
                        new Vector2(x, y),
                        PositionStateExtension.GetFromNumber(d)
                    ));
                    x++;
                }
                y++;
                x = 0;
            }
            Init(Size, pos, playerPos);
        }
        public Level(string name, Vector2 size, List<Position> positions)
            : base(size, positions, new Vector2(0, 0))
        { Name = name; }

        public void Unlock()
        {
            Unlocked = true;
        }
    }
}
