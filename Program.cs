using System;

namespace Dnd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CharacterManager manager = new CharacterManager();
            bool running = true;

            // 8. Консольне меню програми (Вимога 8)
            while (running)
            {
                Console.WriteLine("       МЕНЮ");
                Console.WriteLine("1 – Додати об'єкт");
                Console.WriteLine("2 – Переглянути всі об'єкти");
                Console.WriteLine("3 – Знайти об'єкт");
                Console.WriteLine("4 – Продемонструвати поведінку");
                Console.WriteLine("5 – Видалити об'єкт");
                Console.WriteLine("0 – Вийти з програми");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.AddCharacter();
                        break;
                    case "2":
                        manager.ShowAllCharacters();
                        break;
                    case "3":
                        manager.FindCheracter();
                        break;
                    case "4":
                        manager.DemonstrateBehavior();
                        break;
                    case "5":
                        manager.DeleteCharacter();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Завершення роботи програми.");
                        break;
                    default:
                        Console.WriteLine("Некоректний вибір! Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}