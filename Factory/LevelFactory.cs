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
            name: "Level 1",
            data: new int[][]
            {
                new int[] {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
                new int[] {2, 0, 0, 0, 0, 0, 0, 3, 4, 0, 2},
                new int[] {2, 2, 2, 0, 0, 2, 0, 2, 2, 0, 2},
                new int[] {2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                new int[] {2, 2, 2, 2, 0, 3, 0, 0, 2, 3, 2},
                new int[] {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}
            },
            playerPos: new Vector2(1, 1)
        )
        { Unlocked = true };

        public static Level Level2 = new Level(
            name: "Level 2",
            data: new int[][]
            {
                new int[] {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
                new int[] {2, 0, 0, 0, 0, 3, 0, 3, 0, 0, 2},
                new int[] {2, 2, 2, 3, 0, 0, 0, 2, 2, 0, 2},
                new int[] {2, 0, 0, 0, 2, 3, 0, 0, 0, 0, 2},
                new int[] {2, 4, 3, 0, 0, 0, 0, 0, 2, 3, 2},
                new int[] {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}
            },
            playerPos: new Vector2(1, 1)
        );
        public static List<Level> Levels = new List<Level>
        {
            Level1,
            Level2,
        };
    }
}
