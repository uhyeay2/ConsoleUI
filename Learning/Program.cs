using ConsoleUIManager;
using System;

namespace Learning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(140, 30);

            Showcase.Start();
        }
    }
}