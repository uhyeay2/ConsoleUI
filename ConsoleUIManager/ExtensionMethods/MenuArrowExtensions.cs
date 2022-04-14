using ConsoleUIManager.Enums;
using System;
using System.Collections.Generic;

namespace ConsoleUIManager.ExtensionMethods
{
    public static class MenuArrowExtensions
    {
        /// <summary>
        /// Apply "--> " or " <--" before and/or after the string at the provided index.
        /// Which arrows to use is dependant upon MenuArrow Enum - Before, After, BeforeAndAfter
        /// </summary>
        /// <param name="menuArrow"></param>
        /// <param name="strings"></param>
        /// <param name="indexToApply"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IEnumerable<string> ApplyArrows(this MenuArrow menuArrow, IEnumerable<string> strings, int indexToApply)
        {
            return menuArrow switch
            {
                MenuArrow.BeforeAndAfter => strings.PadRightToEqualLengths().InsertArrowBeforeAndAfterIndex(indexToApply),

                MenuArrow.Before => strings.InsertArrowBeforeIndex(indexToApply),

                MenuArrow.After => strings.PadRightToEqualLengths().InsertArrowAfterIndex(indexToApply),

                _ => throw new NotImplementedException(
                    $"MenuArrowExtensions.ApplyArrows() is not built to handle a MenuArrow of {nameof(menuArrow)}"),
            };
        }
    }
}