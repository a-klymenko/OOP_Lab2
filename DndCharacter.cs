using System;

namespace Dnd
{
    public class DndCharacter
    {
        //ін приватні поля
        private string name;
        private CharacterClass charClass;
        private int level;
        private int helth;

        public string Faction {get; set;}=" Guild"; //авто аластивості з за замовчуванням
        public int Exerience {get; private set;}=0; //різні рівні доступу 

         // перевірка змісту імені власт
        public string Name
        {
            get {return name;}
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Назвись");
                name = value;
            }
        }

        //аеревірка класу власт
        public CharacterClass Class
        {
            get{return charClass;}
            set
            {
                if(!Enum.IsDefined(typeof(CharacterClass),value))
                    throw new Exception ("Обрано неіснуючого персонажа");
                charClass = value;
            }
        }

        //перевірка рівня власт
        public int Level
        {
            get{return level;}
            set
            {
                if (value<1 || value>20)
                    throw new Exception("рівень від 1 до 20");
                level = value;
            }
        }

        //перевірка здоров'я власт 
        public int Helth
        {
            get{return helth;}
            set
            {
                if(value<0)
                    throw new Exception("Здоров'я не може бути 0");
                helth=value;
            }
        }

        //повне ім'я, титул властвивість
        public string FullTitle
        {
            get{return $"{Name}({Class})- рівень {level}";}
        }

        //конструктор без з пораметрами 
        public DndCharacter(){}

        public DndCharacter(string name, CharacterClass charClass, int level, int helth)
        {
            Name=name;
            Class=charClass;
            Level=level;
            Helth=helth;
        }

        // метод 
        private void LogAction(string message)
        {
            Console.WriteLine($"[LOG]:{message}");
        }

        //метод
        public void GainExperience(int amount)
        {
            if (amount<=0)return;
            Exerience+=amount;
            LogAction($"Персонаж {Name} отримав {amount} досвіду, всього досвіду {Exerience}");
        }

        //метод
        public void TakeDamage(int damage)
        {
            Helth=Math.Max(0, Helth-damage);
            LogAction($"Персонаж {Name} отримав {damage} урону, залишилось здоров'я {Helth}");
        }

        //метод 
        public override string ToString()
        {
            return $"[Персонаж]{FullTitle}| Фракція:{Faction}| Здоров'я :{Helth}| Досвід:{Exerience}";
        }

    }
}