using MoveOrDie.Entities;
using MoveOrDie.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Factory
{
    internal class LevelFactory
    {
        public static Level Level1 = new Level(
            data: new int[][]
            {
                new int[] {2, 2, 2, 2, 2},
                new int[] {2, 1, 0, 0, 2},
                new int[] {2, 2, 2, 0, 2},
                new int[] {2, 0, 0, 0, 2},
                new int[] {2, 2, 2, 2, 2}
            }
        );
    }
}
