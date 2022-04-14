using System.Collections.Generic;
using System.Linq;

namespace ConsoleUIManager.ExtensionMethods
{
    public static class StringArrayExtensions
    {
        #region Insert Arrow Before and/or After by index

        /// <summary>
        /// First pad all strings to equal length. Then Insert " <--" after the string at index provided.
        /// Insert "    " after all other strings to keep the spacing the same.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<string> InsertArrowAfterIndex(this IEnumerable<string> strings, int index)
        {
            return strings.Select((s, i) => s.InsertArrowAfter(i == index));
        }

        /// <summary>
        /// Insert "--> " before and " <--" after the string at index provided. Insert "    " before and after all
        /// other strings to keep spacing the same.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<string> InsertArrowBeforeAndAfterIndex(this IEnumerable<string> strings, int index)
        {
            return strings.Select((s, i) => s.InsertArrowBeforeAndAfter(i == index));
        }

        /// <summary>
        /// Insert "--> " before the string at index provided. Insert "    " before all others strings to keep spacing the same.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<string> InsertArrowBeforeIndex(this IEnumerable<string> strings, int index)
        {
            return strings.Select((s, i) => s.InsertArrowBefore(i == index));
        }

        #endregion Insert Arrow Before and/or After by index

        #region Apply Border

        public static IEnumerable<string> CenteredInsideSimpleBorder(this IEnumerable<string> strings, int borderWidth)
        {
            return strings.PadToCenter(borderWidth).InsideSimpleBorder(borderWidth);
        }

        /// <summary>
        /// Returns the collection of strings with a simple border around it using '_' and '|' characters
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="borderWidth"></param>
        /// <returns></returns>
        public static IEnumerable<string> InsideSimpleBorder(this IEnumerable<string> strings, int borderWidth)
        {
            var paddingWidth = borderWidth - 2;

            var topBorder = new string[]
            {
                " _".PadRight(paddingWidth, '_') + "_ ",
                "|".PadRight(paddingWidth) + " |"
            };
            var textLines = strings.PadRightToEqualLengths().Select(t => $"| {t.PadRight(paddingWidth - 1)}|");

            var bottomBorder = new string[] { "|".PadRight(paddingWidth, '_') + "_|" };

            return topBorder.Concat(textLines).Concat(bottomBorder);
        }

        #endregion Apply Border

        #region Pad To Sides

        /// <summary>
        /// Pad the collection of strings to the left so that they are all the same length.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static IEnumerable<string> PadLeftToEqualLengths(this IEnumerable<string> strings)
        {
            var maxLength = strings.Max(s => s.Length);
            return strings.Select(s => s.PadLeft(maxLength));
        }

        /// <summary>
        /// Pad the collection of strings so the right so that they are all the same length.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static IEnumerable<string> PadRightToEqualLengths(this IEnumerable<string> strings)
        {
            var maxLength = strings.Max(s => s.Length);
            return strings.Select(s => s.PadRight(maxLength));
        }

        #endregion Pad To Sides

        #region PadToCenter

        /// <summary>
        /// Pad the collection of strings so that they are all centered within the ConsoleWidth
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static IEnumerable<string> PadToCenter(this IEnumerable<string> strings)
        {
            return strings.Select(s => s.PadToCenter());
        }

        /// <summary>
        /// Pad the collection of strings so that they are all centered within the targetLength provided.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="targetLength"></param>
        /// <returns></returns>
        public static IEnumerable<string> PadToCenter(this IEnumerable<string> strings, int targetLength)
        {
            return strings.Select(s => s.PadToCenter(targetLength));
        }

        #endregion PadToCenter
    }
}