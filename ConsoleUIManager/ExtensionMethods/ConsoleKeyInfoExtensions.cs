using System;

namespace ConsoleUIManager.ExtensionMethods
{
    public static class ConsoleKeyInfoExtensions
    {
        public static bool TryGetIndex(this ConsoleKeyInfo readKey, int maxIndex, ref int currentIndex)
        {
            switch (readKey.Key)
            {
                case ConsoleKey.Enter:
                    return true;

                case ConsoleKey.UpArrow:
                    // 0 goes to max, everything else goes down
                    currentIndex = currentIndex == 0 ? --maxIndex : --currentIndex;
                    return false;

                case ConsoleKey.DownArrow:
                    // max goes to 0, everything else goes up
                    currentIndex = currentIndex == --maxIndex ? 0 : ++currentIndex;
                    return false;

                default: return false;
            }
        }
    }
}