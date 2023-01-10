using MoveOrDie.Factory;

namespace MoveOrDie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var level = LevelFactory.Level1;
            level.Draw();
        }
    }
}