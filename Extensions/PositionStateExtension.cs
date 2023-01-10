using MoveOrDie.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOrDie.Extensions
{
    internal static class PositionStateExtension
    {
        internal static string AsString(this PositionState state)
        {
            return state switch
            {
                PositionState.Empty => ". ",
                PositionState.Player => "O ",
                PositionState.Obstacle => "X ",
                _ => ""
            };
        }
        internal static PositionState GetFromNumber(int number)
        {
            return number switch
            {
                0 => PositionState.Empty,
                1 => PositionState.Player,
                2 => PositionState.Obstacle,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
