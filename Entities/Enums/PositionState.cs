using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Entities.Enums
{
    internal enum PositionState
    {
        Empty = 0,
        Player = 1,
        Obstacle = 2,
        Enemy = 3,
        Goal = 4,
    }
}
