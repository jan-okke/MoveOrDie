using MoveOrDie.Entities;
using MoveOrDie.Entities.Enums;
using MoveOrDie.Factory;
using OpenTK.Windowing.Desktop;

namespace MoveOrDie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var level = LevelFactory.Level1;
            while (true)
            {
                Console.Clear();
                level.Draw();
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        level.Move(Direction.Up); break;
                    case ConsoleKey.DownArrow:
                        level.Move(Direction.Down); break;
                    case ConsoleKey.RightArrow:
                        level.Move(Direction.Right); break;
                    case ConsoleKey.LeftArrow:
                        level.Move(Direction.Left); break;
                }
                if (level.GameOver)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You lost!");
                    Console.ResetColor();
                    break;
                }
                if (level.MapComplete)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You won!");
                    Console.ResetColor();
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}