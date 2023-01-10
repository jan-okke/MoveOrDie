using MoveOrDie.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Entities
{
    internal class Position
    {
        public Vector2 WorldPosition;
        public PositionState State;

        public Position(Vector2 worldPosition, PositionState state)
        {
            WorldPosition = worldPosition;
            State = state;
        }
    }
}
