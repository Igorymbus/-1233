using System;
using System.Collections.Generic;
using System.IO;

// Класс для подпункта меню
public class MenuItem
{
    public string Description { get; set; }
    public decimal Price { get; set; }

    public MenuItem(string description, decimal price)
    {
        Description = description;
        Price = price;
    }
}

// Класс для заказа
public class CakeOrder
{
    private List<MenuItem> mainMenu;
    private Dictionary<string, List<MenuItem>> subMenus;
    private List<MenuItem> currentOrder;

    public CakeOrder()
    {
        mainMenu = new List<MenuItem>
        {
            new MenuItem("Форма", 0),
            new MenuItem("Размер", 0),
            new MenuItem("Вкус", 0),
            new MenuItem("Количество", 0),
            new MenuItem("Глазурь", 0),
            new MenuItem("Декор", 0),
        };

        // Здесь добавьте подпункты меню для каждого пункта основного меню
        subMenus = new Dictionary<string, List<MenuItem>>
        {
            { "Форма", new List<MenuItem>
                {
                    new MenuItem("Круглая", 10),
                    new MenuItem("Квадратная", 12),
                    new MenuItem("Сердце", 15)
                }
            },
            // Добавьте подпункты для остальных пунктов основного меню
        };

        currentOrder = new List<MenuItem>();
    }

    public void StartOrder()
    {
        bool isOrdering = true;

        while (isOrdering)
        {
            Console.Clear();
            Console.WriteLine("Выберите пункт из основного меню:");

            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mainMenu[i].Description}");
            }

            int choice = ReadIntegerInput(1, mainMenu.Count);

            string selectedMenu = mainMenu[choice - 1].Description;

            if (subMenus.ContainsKey(selectedMenu))
            {
                bool isSubMenu = true;

                while (isSubMenu)
                {
                    Console.Clear();
                    Console.WriteLine($"Выберите {selectedMenu}:");
                    List<MenuItem> submenu = subMenus[selectedMenu];

                    for (int i = 0; i < submenu.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {submenu[i].Description} (${submenu[i].Price})");
                    }

                    int subChoice = ReadIntegerInput(1, submenu.Count);

                    currentOrder.Add(submenu[subChoice - 1]);

                    Console.WriteLine("Добавить еще один пункт? (Y/N)");
                    if (Console.ReadKey().Key != ConsoleKey.Y)
                    {
                        isSubMenu = false;
                    }
                }
            }
            else
            {
                currentOrder.Add(mainMenu[choice - 1]);
            }

            Console.WriteLine("Заказ завершен. Сохранить его? (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                SaveOrder();
                currentOrder.Clear();
            }

            Console.WriteLine("Хотите сделать еще один заказ? (Y/N)");
            if (Console.ReadKey().Key != ConsoleKey.Y)
            {
                isOrdering = false;
            }
        }
    }

    private void SaveOrder()
    {
        string orderDetails = string.Join(", ", currentOrder.Select(item => $"{item.Description} (${item.Price})"));
        decimal totalCost = currentOrder.Sum(item => item.Price);

        using (StreamWriter sw = File.AppendText("История заказов.txt"))
        {
            sw.WriteLine($"Заказ: {orderDetails}");
            sw.WriteLine($"Суммарная стоимость: ${totalCost}");
            sw.WriteLine();
        }
    }

    private int ReadIntegerInput(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.WriteLine("Неверный выбор. Пожалуйста, введите правильное значение.");
        }
        return choice;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CakeOrder cakeOrder = new CakeOrder();
        cakeOrder.StartOrder();
    }
}