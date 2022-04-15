using ConsoleUIManager.ExtensionMethods;
using ConsoleUIManager.Screens;
using System;
using System.Collections.Generic;

namespace ConsoleUIManager
{
    public static class Showcase
    {
        private static readonly Dictionary<string, string[]> Messages = new()
        {
            {
                "Start",
                new string[]
                {
                "Hello, welcome to my ConsoleUI Showcase!", "",
                "To make use of this UI, you will most likely use the following classes:",
                "1) TextBox   ",
                "2) Screen    ",
                "3) MenuScreen", "",
                "However there are plenty of other features easily available with extension methods.",
                "Some of these features include:",
                "1) Automatic Padding",
                "2) Inserting Arrows ",
                "3) Applying a Border", "",
                "I hope you like it!".InsertArrowBeforeAndAfter(), "",
                "Press any key to continue.", "", "",
                "Created by Daniel Aguirre"
                }
            },
            {
                "IntroToMainMenu",
                new string[]{
                "The previous screen, and this one, were both printed using the Screen.PrintCentered() method.",
                "First the messages to be printed are being assigned to a Textbox.",
                "After that the textBox.TextCenteredInsideBorder property is passed into PrintCentered()",
                "That is how these strings are centered inside a border!", "",
                "The next screen I show will be a menu. That screen is created using the MenuScreen class.",
                "The MenuScreen class will take in an IEnumerable<string> for your messages.",
                "It will also take an IEnumerable<string> for your menu options.", "",
                "You can scroll up and down with the arrow keys, and press Enter to select.",
                "This method does require an int for the width of the textBox to use.",
                "Lastly, there is an enum you can pass in for where to place the menu arrows.",
                "You can place the arrows before, after, or before and after the selected index.",
                "","Press any key to advance to the menu."
                }
            },
            {
                "MainMenu",
                new string[]
                {
                    "This is a selection of features in this project.",
                    "Select which one you would like to view.",
                    ""
                }
            },
            {
                "MainMenuOptions",
                new string[]
                {
                    "Padding - Center, Left, Right",
                    "Border - Simple Border Around Messages",
                    "Arrows - For Menus or any string",
                    "TextBox - Used for easy formatting",
                    "Screen Class - Primary Screen Printer",
                    "MenuScreen Class - Custom Menu Screens",
                    "Exit - End the application"
                }
            },
            {
                "Padding",
                new string[]
                {
                    "Up until now, everything has been centered. But There's more that can be done too", "",
                    "You can pad to the left,",
                    "You can pad to the center of a desired target length,",
                    "Or you can pad to the right",
                    "",
                    "These can be applied using an IEnumerable<string> extension method.",
                    "There are also easy ways to align text with the Textbox and Screen/MenuScreen classes",
                    "", "Press any key to continue."
                }
            },
            {
                "PaddingExit",
                new string[] {
                "This is the end of the showcase for Padding.", "",
                "These examples were created by using string[] Extension Methods:",
                ".PadLeftToEqualLengths() and .PadRightToEqualLengths()", "",
                "You can also use .PadToCenter() and pass in the target length to center within",
                "If you don't pass in a targetLength then PadToCenter() will center within the window"}
            }
        };

        public static TextBox TextBox { get; set; } = new(120);

        public static void Start()
        {
            Screen.SleepTime = 120;
            Console.Title = "ConsoleUIManager - Showcase";

            PrintCenteredReadKey(Messages["Start"]);

            MainMenu();
        }

        private static void MainMenu()
        {
            PrintCenteredReadKey(Messages["IntroToMainMenu"]);

            var appRunning = true;

            while (appRunning)
            {
                var selection = MenuScreen.PrintCenteredInsideBorderWithNestedOptionsBorder(
                    Messages["MainMenu"], Messages["MainMenuOptions"], TextBox.BoxWidth);

                PrintCenteredReadKey(new string[] { "You selected:", Messages["MainMenuOptions"][selection] });

                switch (selection)
                {
                    // Padding
                    case 0:
                        Padding();
                        break;
                    // Border
                    case 1:

                        break;
                    // Arrows
                    case 2:

                        break;
                    // TextBox
                    case 3:

                        break;

                    // screen class
                    case 4:

                        break;

                    // menu screen
                    case 5:

                        break;

                    //exit
                    default:
                        appRunning = false;
                        break;
                }
            }
        }

        private static void Padding()
        {
            PrintCenteredReadKey(Messages["Padding"]);

            PrintCenteredReadKey(Messages["Padding"].PadRightToEqualLengths());

            PrintCenteredReadKey(Messages["Padding"].PadLeftToEqualLengths());

            PrintCenteredReadKey(Messages["PaddingExit"]);
        }

        private static void PrintCenteredReadKey(IEnumerable<string> messages)
        {
            TextBox.SetText(messages);
            Screen.PrintCentered(TextBox.TextCenteredInsideBorder);
            Console.ReadKey();
        }
    }
}