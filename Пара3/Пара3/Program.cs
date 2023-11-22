using System;

class Program
{
    public static void Main()
    {
        while (Menu() != 0) ;
    }

    static int Menu()
    {
        int choice;
        Console.WriteLine("Выберите программу:");
        Console.WriteLine("1. Игра \"Угадай число\"");
        Console.WriteLine("2. Таблица умножения");
        Console.WriteLine("3. Вывод делителей числа");
        Console.WriteLine("0. Выход");

        bool parseSuccess = Int32.TryParse(Console.ReadLine(), out choice);

        if (!parseSuccess)
        {
            Console.WriteLine("Неправильный ввод. Введите число.");
            return -1;
        }

        switch (choice)
        {
            case 1:
                PlayGuessingGame();
                break;
            case 2:
                PrintMultiplicationTable();
                break;
            case 3:
                DisplayDivisors();
                break;
            case 0:
                Console.WriteLine("До свидания!");
                break;
            default:
                Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                break;
        }
        return choice;
    }

    static void PlayGuessingGame()
    {
        Random random = new Random();
        int secretNumber = random.Next(0, 101);
        GuessNumber(secretNumber);
    }

    static void GuessNumber(int number)
    {
        int guess;
        int tries = 0;
        do
        {
            tries++;
            Console.Write("Введите число от 0 до 100: ");
            int.TryParse(Console.ReadLine(), out guess);
            if (guess > number)
            {
                Console.WriteLine("Загаданное число меньше.");
            }
            else if (guess < number)
            {
                Console.WriteLine("Загаданное число больше.");
            }
        } while (guess != number);
        Console.WriteLine($"Вы угадали число {number} за {tries} попыток.");
    }

    static void PrintMultiplicationTable()
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                Console.Write($"{i * j}\t");
            }
            Console.WriteLine();
        }
    }

    static void DisplayDivisors()
    {
        int number;
        do
        {
            Console.Write("Введите число (для выхода введите 0): ");
            int.TryParse(Console.ReadLine(), out number);
            if (number != 0)
            {
                FindAndPrintDivisors(number);
            }
        } while (number != 0);
    }

    static void FindAndPrintDivisors(int number)
    {
        Console.Write($"Делители числа {number}: ");
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }
}