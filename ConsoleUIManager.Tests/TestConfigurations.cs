using System;
using System.Linq;

namespace ConsoleUIManager.Tests
{
    internal static class TestConfigurations
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int RandomNumberDefaultMaxLength = 50;
        private static Random _random = new();

        public static int RandomNumber(int maxLength = RandomNumberDefaultMaxLength)
        {
            return _random.Next(maxLength);
        }

        public static string RandomString(int length)
        {
            return new string(Enumerable.Range(0, length).Select(i =>
                    Chars[_random.Next(Chars.Length)]).ToArray());
        }
    }
}