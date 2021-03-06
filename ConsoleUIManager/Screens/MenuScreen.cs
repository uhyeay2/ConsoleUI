using ConsoleUIManager.Enums;
using ConsoleUIManager.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUIManager.Screens
{
    public static class MenuScreen
    {
        /// <summary>
        /// The Screen class has a SleepTime field that will slow down the speed that screens are printed at.
        /// This is not desirable on menu screens, so this feature is disabled by default for menu screens.
        /// </summary>
        public static bool DisableScreenSleepTime = true;

        /// <summary>
        /// Private LastSleepTime field used when reactivating SleepTime if DisableScreenSleepTime is true.
        /// </summary>
        private static int LastSleepTime;

        #region With Border

        /// <summary>
        /// Print the provided strings followed by the menuOptions, inside a border.
        /// Creates a TextBox using the provided width for printing the screen.
        /// The users current selection is outlined with arrows on both sides by default but can be adjusted to Before or After.
        /// Returns and int matching the index of the current selection when the user clicks enter.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="menuOptions"></param>
        /// <param name="textBoxWidth"></param>
        /// <param name="arrows"></param>
        /// <returns></returns>
        public static int PrintCenteredInsideBorder(IEnumerable<string> strings, IEnumerable<string> menuOptions, int textBoxWidth, MenuArrow arrows = MenuArrow.BeforeAndAfter)
        {
            var textBox = new TextBox(textBoxWidth);

            var selectionMade = false;
            var selectedIndex = 0;

            DisableSleepTime();

            while (!selectionMade)
            {
                textBox.SetText(strings, arrows.ApplyArrows(menuOptions, selectedIndex));

                Screen.PrintCentered(textBox.TextInsideBorder);

                selectionMade = Console.ReadKey().TryGetIndex(menuOptions.Count(), ref selectedIndex);
            }

            EnableSleepTime();

            return selectedIndex;
        }

        /// <summary>
        /// Print the provided strings followed by the menuOptions. Use a outer border and place menuOptions in an inner border.
        /// Creates a TextBox using the provided width for printing the screen.
        /// The users current selection is outlined with arrows on both sides by default but can be adjusted to Before or After.
        /// Returns and int matching the index of the current selection when the user clicks enter.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="menuOptions"></param>
        /// <param name="textBoxWidth"></param>
        /// <param name="arrows"></param>
        /// <returns></returns>
        public static int PrintCenteredInsideBorderWithNestedOptionsBorder
            (IEnumerable<string> strings, IEnumerable<string> menuOptions, int textBoxWidth, MenuArrow arrows = MenuArrow.BeforeAndAfter)
        {
            var textBox = new TextBox(textBoxWidth);

            var selectionMade = false;
            var selectedIndex = 0;

            DisableSleepTime();

            while (!selectionMade)
            {
                textBox.SetText(strings, arrows.ApplyArrows(menuOptions, selectedIndex).InsideSimpleBorder(menuOptions.Max(m => m.Length) + 14));

                Screen.PrintCentered(textBox.TextCenteredInsideBorder);

                selectionMade = Console.ReadKey().TryGetIndex(menuOptions.Count(), ref selectedIndex);
            }

            EnableSleepTime();

            return selectedIndex;
        }

        #endregion With Border

        #region Print Without Border

        /// <summary>
        /// Print the provided strings followed by the menuOptions. Creates a TextBox using the provided width for printing the screen.
        /// The users current selection is outlined with arrows on both sides by default but can be adjusted to Before or After.
        /// Returns and int matching the index of the current selection when the user clicks enter.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="menuOptions"></param>
        /// <param name="textBoxWidth"></param>
        /// <param name="arrows"></param>
        /// <returns></returns>
        public static int PrintCentered(IEnumerable<string> strings, IEnumerable<string> menuOptions, int textBoxWidth, MenuArrow arrows = MenuArrow.BeforeAndAfter)
        {
            var textBox = new TextBox(textBoxWidth);

            var selectionMade = false;
            var selectedIndex = 0;

            DisableSleepTime();

            while (!selectionMade)
            {
                textBox.SetText(strings, arrows.ApplyArrows(menuOptions, selectedIndex));

                Screen.PrintCentered(textBox.TextCentered);

                selectionMade = Console.ReadKey().TryGetIndex(menuOptions.Count(), ref selectedIndex);
            }

            EnableSleepTime();

            return selectedIndex;
        }

        /// <summary>
        /// Print the provided strings followed by the menuOptions. Creates a TextBox using the provided width for printing the screen.
        /// The users current selection is outlined with arrows on both sides by default but can be adjusted to Before or After.
        /// Returns and int matching the index of the current selection when the user clicks enter.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="menuOptions"></param>
        /// <param name="textBoxWidth"></param>
        /// <param name="arrows"></param>
        /// <returns></returns>
        public static int PrintCenteredWithOptionsInBorder(IEnumerable<string> strings, IEnumerable<string> menuOptions, int textBoxWidth, MenuArrow arrows = MenuArrow.BeforeAndAfter)
        {
            var textBox = new TextBox(textBoxWidth);

            var selectionMade = false;
            var selectedIndex = 0;

            DisableSleepTime();

            while (!selectionMade)
            {
                textBox.SetText(strings, arrows.ApplyArrows(menuOptions, selectedIndex).InsideSimpleBorder(menuOptions.Max(m => m.Length) + 14));

                Screen.PrintCentered(textBox.TextCentered);

                selectionMade = Console.ReadKey().TryGetIndex(menuOptions.Count(), ref selectedIndex);
            }

            EnableSleepTime();

            return selectedIndex;
        }

        #endregion Print Without Border

        #region Helper Methods

        /// <summary>
        /// Helper method to set Screen.SleepTime to 0 when DisableScreenSleepTime is true.
        /// </summary>
        private static void DisableSleepTime()
        {
            if (DisableScreenSleepTime)
            {
                LastSleepTime = Screen.SleepTime;
                Screen.SleepTime = 0;
            }
        }

        /// <summary>
        /// Helper method to set Screen.SleepTime back to the LastSleepTime if it was previously disabled.
        /// </summary>
        private static void EnableSleepTime()
        {
            if (DisableScreenSleepTime)
            {
                Screen.SleepTime = LastSleepTime;
            }
        }

        #endregion Helper Methods
    }
}