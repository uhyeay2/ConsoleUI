using ConsoleUIManager.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUIManager.Screens
{
    public static class Screen
    {
        public static int SleepTime { get; set; } = 0;

        /// <summary>
        /// Print the collection of strings to the console. Clear the screen first.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="clearBeforePrint"></param>
        public static void Print(IEnumerable<string> strings, bool clearBeforePrint = true)
        {
            ScreenHelper.ClearScreen(clearBeforePrint);

            ScreenHelper.Print(strings, SleepTime);
        }

        /// <summary>
        /// Clear the screen then print the collection of strings to the console centered both vertically and horizontally.
        /// </summary>
        /// <param name="strings"></param>
        public static void PrintCentered(IEnumerable<string> strings)
        {
            ScreenHelper.CenterVertically(strings.Count());

            PrintCenteredHorizontally(strings);
        }

        /// <summary>
        /// Print the collection of strings to the console centered horizontally.
        /// Boolean to clear the screen before printing defaults to false.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="clearScreen"></param>
        public static void PrintCenteredHorizontally(IEnumerable<string> strings, bool clearScreen = false)
        {
            ScreenHelper.ClearScreen(clearScreen);

            ScreenHelper.Print(strings.PadToCenter(), SleepTime);
        }

        /// <summary>
        /// Clear the screen then print the collection of strings to the console centered vertically.
        /// </summary>
        /// <param name="strings"></param>
        public static void PrintCenteredVertically(IEnumerable<string> strings)
        {
            ScreenHelper.CenterVertically(strings.Count());

            ScreenHelper.Print(strings, SleepTime);
        }
    }
}