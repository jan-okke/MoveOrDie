using MoveOrDie.Entities;
using MoveOrDie.Entities.Enums;
using MoveOrDie.Factory;

namespace MoveOrDie
{
    internal class Program
    {
        static bool PlayLevel(Level level)
        {
            DateTime start = DateTime.Now;
            while (true)
            {
                Console.Clear();
                level.Draw(DateTime.Now - start);
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
                    case ConsoleKey.Escape:
                        throw new Exception();
                }
                if (level.GameOver)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You lost!");
                    Console.ResetColor();
                    return false;
                }
                if (level.MapComplete)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You won! Final Time: {DateTime.Now - start}");
                    Console.ResetColor();
                    level.SetRecord(DateTime.Now - start);
                    return true;
                }
            }
        }
        static Level ChooseLevel()
        {
            int selectedLevel = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose your level:");
                for (int i = 0; i < LevelFactory.Levels.Count; i++)
                {
                    Level l = LevelFactory.Levels[i];
                    if (i == selectedLevel) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
                    if (l.Unlocked)
                    {
                        Console.WriteLine($"=> {l.Name}");
                    }
                    Console.ResetColor();
                }
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    
                    case ConsoleKey.Spacebar or ConsoleKey.A or ConsoleKey.Enter:
                        var level = LevelFactory.Levels[selectedLevel];
                        level.RelocatePlayer();
                        return level;
                        //return LevelFactory.Levels[selectedLevel];
                    case ConsoleKey.UpArrow:
                        if (selectedLevel == 0) continue;
                        selectedLevel--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedLevel == LevelFactory.Levels.Count - 1) continue;
                        if (LevelFactory.Levels[selectedLevel + 1].Unlocked) selectedLevel++;
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                var level = ChooseLevel();
                var index = LevelFactory.Levels.IndexOf(level);
                try
                {
                    if (PlayLevel(level))
                    {
                        try
                        {
                            LevelFactory.Levels[index + 1].Unlock();
                        }
                        catch { }
                    }
                    Console.ReadKey();
                }
                catch { }
            }
            // Add TIMER => Gold Silber Bronze
        }
    }
}