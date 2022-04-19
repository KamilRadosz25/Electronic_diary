using System;

namespace Diary.Helpers
{
    public static class ConsoleHelpers
    {
        public static void WriteLineWithColor(string? value, ConsoleColor consoleColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }
}