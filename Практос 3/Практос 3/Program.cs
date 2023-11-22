using System;
using System.Threading;

class Piano
{
    // Массивы частот для каждой октавы
    static int[] firstOctave = new int[] { 262, 294, 330, 349, 392, 440, 494 };
    static int[] secondOctave = new int[] { 523, 587, 659, 698, 784, 880, 988 };
    static int[] thirdOctave = new int[] { 1047, 1175, 1319, 1397, 1568, 1760, 1976 };

    static int currentOctave = 1; // Текущая октава

    static void Main()
    {
        Console.WriteLine("Добро пожаловать в пианино!");

        while (true)
        {
            Console.WriteLine("Используйте клавиши A-K для белых клавиш и W-U для черных клавиш (без октавы).");
            Console.WriteLine("Используйте клавиши F1, F2, F3 для переключения между октавами.");
            Console.WriteLine("Нажмите Escape для выхода.");

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Escape)
                break;

            if (key.Key == ConsoleKey.F1)
            {
                currentOctave = 1;
                Console.WriteLine("\nПереключено на первую октаву.\n");
                continue;
            }
            else if (key.Key == ConsoleKey.F2)
            {
                currentOctave = 2;
                Console.WriteLine("\nПереключено на вторую октаву.\n");
                continue;
            }
            else if (key.Key == ConsoleKey.F3)
            {
                currentOctave = 3;
                Console.WriteLine("\nПереключено на третью октаву.\n");
                continue;
            }

            PlaySound(key.KeyChar);
        }

        Console.WriteLine("До свидания!");
    }

    // Метод для воспроизведения звука
    static void PlaySound(char key)
    {
        int index = GetKeyIndex(key);

        if (index != -1)
        {
            int[] octave = GetOctaveNotes(currentOctave);
            Console.WriteLine($"\nИграет нота {key} ({octave[index]} Гц)\n");
            Console.Beep(octave[index], 500); // Издаем звук с заданной частотой на 0.5 секунды
        }
        else
        {
            Console.WriteLine("\nНедопустимый символ!\n");
        }
    }

    // Метод для получения индекса ноты в массиве
    static int GetKeyIndex(char key)
    {
        switch (char.ToUpper(key))
        {
            case 'A': return 0;
            case 'S': return 1;
            case 'D': return 2;
            case 'F': return 3;
            case 'G': return 4;
            case 'H': return 5;
            case 'J': return 6;
            case 'W': return 0;
            case 'E': return 1;
            case 'T': return 3;
            case 'Y': return 4;
            case 'U': return 5;
            default: return -1;
        }
    }

    // Метод для получения массива частот для указанной октавы
    static int[] GetOctaveNotes(int octave)
    {
        switch (octave)
        {
            case 1: return firstOctave;
            case 2: return secondOctave;
            case 3: return thirdOctave;
            default: return firstOctave;
        }
    }
}