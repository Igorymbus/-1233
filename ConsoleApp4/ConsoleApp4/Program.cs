using System;
using System.Collections.Generic;

public class ArrowMenu
{
    public static int ShowMenu(List<string> options)
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(options.Count - 1, selectedIndex + 1);
                    break;
                case ConsoleKey.Enter:
                    return selectedIndex;
            }
        }
    }

    public static void Main(string[] args)
    {
        List<string> menuOptions = new List<string>
        {
            "Option 1",
            "Option 2",
            "Option 3",
            "Option 4"
        };

        int selectedOption = ShowMenu(menuOptions);

        Console.Clear();
        Console.WriteLine($"Selected option: {menuOptions[selectedOption]}");
    }
}