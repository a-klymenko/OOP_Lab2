using System;
using System.Collections.Generic;

namespace Dnd
{
    public class CharacterManager
    {
        private readonly List<DndCharacter> characters=new List<DndCharacter>();//створення список зберігання

        //зчитуванння з обробкою
        public void AddCharacter()
        {
            DndCharacter hero = new DndCharacter();
        //ім'я
        while (true)
        {
            try
            {
                Console.Write("ім'я персонажа: ");
                hero.Name=Console.ReadLine();
                break;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"помилка: {ex.Message}");
            }
        }

        // введення класу
        while (true)
        {
                try
                {
                    Console.Write("Оберіть клас: 0-варвор, 1-маг, 2- розбійник ");
                    if (int.TryParse(Console.ReadLine(),out int classNum))
                    {
                        hero.Class=(CharacterClass)classNum;
                        break;
                    }
                    Console.WriteLine("введіть від 0 до 2 ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка :{ex.Message}");
                }
        }

        //рівня
        while (true)
        {
            try
            {
                Console.Write("Введіть рівень від 1 до 20: ");
                if (int.TryParse(Console.ReadLine(), out int lvl))
                {                        
                    hero.Level = lvl;
                    break;
                }
                Console.WriteLine("Помилка: Введіть ціле число!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
        //здоров'я
        while (true)
            {
                try
                {
                    Console.Write("Введіть рівень здоров'я, більше 0: ");
                    if (int.TryParse(Console.ReadLine(), out int hp))
                    {
                        hero.Helth = hp;
                        break;
                    }
                    Console.WriteLine("Помилка: Введіть ціле число!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }

            //додаємо героя ітого
            characters.Add(hero);
            Console.WriteLine("Персонаж додан");
        }

        //список персонажів
        public void ShowAllCharacters()
        {
            if (characters.Count == 0)
            {
                Console.WriteLine("У списку нікого нема");
                return;
            }
            Console.WriteLine("Список персонажів: ");
            for(int i=0;i<characters.Count; i++)
            {
                Console.WriteLine($"{i+1}. {characters[i]}");
            }
        }

        //пошук
        public void FindCheracter()
        {
            Console.WriteLine("Введіть ім'я розшукуємого: ");
            string searchName=Console.ReadLine();

            DndCharacter found=characters.Find(c=>c.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase)); //все одно, мала велика
            if (found != null)
            {
                Console.WriteLine($"Знайдено: {found}");
            }
            else
            {
                Console.WriteLine("Такого ще нема");
            }
        }

        //демонстрація
        public void DemonstrateBehavior()
        {
            if (characters.Count == 0)
            {
                Console.WriteLine("Персонажей нема");
                return;
            }
            
            DndCharacter hero = characters[0]; //
            Console.WriteLine($"\n Демонстрація дій ({hero.Name}):");

            //Виклик публічних методів, що використовують приватні методи
            hero.GainExperience(100);
            hero.TakeDamage(15);
        }

        //видалення персонажа
        public void DeleteCharacter()
        {
            Console.Write("Введіть ім'я для видалення: ");
            string searchName = Console.ReadLine();

            DndCharacter found = characters.Find(c => c.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                characters.Remove(found);
                Console.WriteLine("Персонажа успішно видалено.");
            }
            else
            {
                Console.WriteLine("Такого нема");
            }
        }

    }
}