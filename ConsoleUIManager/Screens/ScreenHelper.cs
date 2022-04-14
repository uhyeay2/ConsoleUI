using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleUIManager.Screens
{
    internal static class ScreenHelper
    {
        /// <summary>
        /// Uses the numberOfStringToPrint to determine how many lines must be skipped.
        /// </summary>
        /// <param name="numberOfStringsToPrint"></param>
        public static void CenterVertically(int numberOfStringsToPrint)
        {
            ClearScreen(true);

            var numberOfLinesToSkip = (Console.WindowHeight / 2) - (numberOfStringsToPrint / 2);

            Console.Write(new string('\n', numberOfLinesToSkip));
        }

        /// <summary>
        /// Clear the screen if clearScreen is true.
        /// </summary>
        /// <param name="clearScreen"></param>
        public static void ClearScreen(bool clearScreen)
        {
            if (clearScreen)
            {
                Console.Clear();
            }
        }

        /// <summary>
        /// Print the collection of strings provided. Make the thread sleep for the length of sleepTime provided (milliseconds)
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="sleepTime"></param>
        public static void Print(IEnumerable<string> strings, int sleepTime = 0)
        {
            strings.ToList().ForEach(s => Print(s, sleepTime));
        }

        /// <summary>
        /// Print to the screen. Make the thread sleep for the length of sleepTime provided (milliseconds)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sleepTime"></param>
        public static void Print(string str, int sleepTime = 0)
        {
            Console.WriteLine(str);
            if (sleepTime > 0)
            {
                Thread.Sleep(sleepTime);
            }
        }
    }
}