using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePiano
{
    class Program
    {
        static int currentOctave = 0;
        static int[][] octaves = new int[][]
        {
            // Примеры частот в герцах для октав
            new int[] {261, 293, 329, 349, 392, 440, 493}, // Октава 1
            new int[] {523, 587, 659, 698, 784, 880, 987}, // Октава 2
            new int[] {1046, 1175, 1319, 1397, 1568, 1760, 1976} // Октава 3
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в консольное пианино!");
            Console.WriteLine("Для игры используйте клавиши на клавиатуре (белые и черные клавиши)");
            Console.WriteLine("Для изменения октавы используйте клавиши F1, F2, F3 и т.п.");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    PlaySound(key);
                    ChangeOctave(key);
                }
            }
        }

        static void PlaySound(ConsoleKeyInfo key)
        {
            // Проверяем нажатую клавишу и играем соответствующую ноту
            switch (key.Key)
            {
                case ConsoleKey.A:
                    Console.Beep(octaves[currentOctave][0], 500);
                    break;
                case ConsoleKey.W:
                    Console.Beep(octaves[currentOctave][1], 500);
                    break;
                case ConsoleKey.S:
                    Console.Beep(octaves[currentOctave][2], 500);
                    break;
                case ConsoleKey.E:
                    Console.Beep(octaves[currentOctave][3], 500);
                    break;
                case ConsoleKey.D:
                    Console.Beep(octaves[currentOctave][4], 500);
                    break;
                case ConsoleKey.F:
                    Console.Beep(octaves[currentOctave][5], 500);
                    break;
                case ConsoleKey.T:
                    Console.Beep(octaves[currentOctave][6], 500);
                    break;
                default:
                    break;
            }
        }

        static void ChangeOctave(ConsoleKeyInfo key)
        {
            // Проверяем нажатую клавишу и изменяем октаву соответственно
            switch (key.Key)
            {
                case ConsoleKey.F1:
                    currentOctave = 0;
                    break;
                case ConsoleKey.F2:
                    currentOctave = 1;
                    break;
                case ConsoleKey.F3:
                    currentOctave = 2;
                    break;
                default:
                    break;
            }
        }
    }
}
