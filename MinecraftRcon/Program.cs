using Avalonia;
using System;


namespace MinecraftRcon
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Console.WindowHeight = 20;
                Console.WindowWidth = 50;
                Console.Title = "Minecraft Rcon console";
                BuildAvaloniaApp()
    .StartWithClassicDesktopLifetime(args);
            }
            finally
            {
                if (App.exitGotCatched == false)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("unexpected fatal exception (no clue why this happens if this happens more often please open a GitHub issue)");
                    Console.ReadKey();
                }
            }
        }
        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }

    public class Methods
    {
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void WriteLine(string message)
        {
            log += message + "\n";
            Console.WriteLine(message);
        }

        public static void printLog()
        {
            Console.Write(log);
        }

        private static string log = "";

    }
}
