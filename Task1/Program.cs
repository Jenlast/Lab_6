using System;

namespace Lab_6_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Оберіть дію:");
                Console.WriteLine("1 - Обробка текстових файлів (Завдання 1)");
                Console.WriteLine("2 - Обробка графічних файлів (Завдання 2)");
                Console.WriteLine("0 - Вихід");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Task1.Execute();
                            Console.WriteLine("Task 1 executed.");
                            break;
                        case "2":
                            Task2.Execute();
                            Console.WriteLine("Task 2 executed.");
                            break;
                        case "0":
                            Console.WriteLine("Вихід з програми.");
                            return;
                        default:
                            Console.WriteLine("Невірний вибір. Будь ласка, оберіть 1 або 2.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Сталася помилка: {ex.Message}");
                }
            }
        }
    }
}