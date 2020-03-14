using System;
using System.Collections.Generic;

namespace MyProgram
{
    partial class Program
    {
        static List<Hero> Heroes = new List<Hero>();

        static bool Colors = true;

        static void Main(string[] args)
        {
            int choice = 0;

            while (choice != 3)
            {
                Console.Clear();
                Console.WriteLine("1. Создать героя");
                if (Heroes.Count != 0) 
                    Console.WriteLine("2. Выбрать из созданных героев");
                Console.WriteLine("3. Выйти из программы\n");
                if (Heroes.Count != 0)
                    Console.WriteLine("4. Удалить героя\n");
                Console.WriteLine("5. Включить/Выключить цветовые модификации");
                
                try
                {
                    choice = Convert.ToByte(Console.ReadLine());
                }
                catch (Exception)
                {

                }
                switch (choice)
                {
                    case 1:
                        Menu(CreateHero());
                        break;
                    case 2:
                        ShowHeroes(Heroes, true);
                        break;
                    case 3:
                        break;
                    case 4:
                        ShowHeroes(Heroes, false);
                        break;
                    case 5:
                        if (!Colors)
                            Colors = true;
                        else
                            Colors = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowHeroes(List<Hero> Heroes, bool choice)
        {
            if (Heroes.Count == 0)
            {
                Console.WriteLine("Список пуст");
                Console.ReadKey();
            }
            else
            {
                for (int i = 0; i < Heroes.Count; i++)
                {
                    int num = i;
                    num++;
                    Console.WriteLine("Герой #" + num);
                    Heroes[i].Show();
                }
            start:
                Console.Write("Введите номер нужного героя - ");
                int count = Convert.ToInt32(Console.ReadLine());
                --count;
                try
                {
                    if (choice)
                    {
                        if (Heroes[count].Get_special() == Hero.Special.Маг)
                            WizardTheme();
                        if (Heroes[count].Get_special() == Hero.Special.Воин)
                            WarriorTheme();
                        if (Heroes[count].Get_special() == Hero.Special.Друид)
                            DruidTheme();
                        if (Heroes[count].Get_special() == Hero.Special.Лекарь)
                            HealerTheme();
                        if (Heroes[count].Get_special() == Hero.Special.Охотник)
                            HunterTheme();
                            Menu(Heroes[count]);
                    }
                    else
                    {
                            Heroes.RemoveAt(count);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Героя под данным номером не существует!");
                    goto start;
                }
            }
        }

        private static void StandartTheme()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WizardTheme()
        {
            if (Colors)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        private static void HunterTheme()
        {
            if (Colors)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void DruidTheme()
        {
            if (Colors)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void WarriorTheme()
        {
            if (Colors)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void HealerTheme()
        {
            if (Colors)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
        }

        private static Hero CreateHero()
        {
            Hero hero;
        link:
            Console.Clear();
            Console.WriteLine(
            "Выберите класс героя:\n" +
            "1. Маг\n" +
            "2. Друид\n" +
            "3. Воин\n" +
            "4. Охотник\n" +
            "5. Лекарь");
            byte choice;
            try
            {
                choice = Convert.ToByte(Console.ReadLine());
            }
            catch (Exception)
            {
                goto link;
            }
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    WizardTheme();
                    Console.WriteLine("Класс - Маг");
                    hero = new Wizard(GetName());
                    Heroes.Add(hero);
                    break;
                case 2:
                    Console.Clear();
                    DruidTheme();
                    Console.WriteLine("Класс - Друид");
                    hero = new Druid(GetName());
                    Heroes.Add(hero);
                    break;
                case 3:
                    Console.Clear();
                    WarriorTheme();
                    Console.WriteLine("Класс - Воин");
                    hero = new Warrior(GetName());
                    Heroes.Add(hero);
                    break;
                case 4:
                    Console.Clear();
                    HunterTheme();
                    Console.WriteLine("Класс - Охотник");
                    hero = new Hunter(GetName());
                    Heroes.Add(hero);
                    break;
                case 5:
                    Console.Clear();
                    HealerTheme();
                    Console.WriteLine("Класс - Лекарь");
                    hero = new Healer(GetName());
                    Heroes.Add(hero);
                    break;
                default:
                    goto link;
            }
            return hero;
        }

        private static string GetName()
        {
            Console.Write("Введите имя - ");
            return Console.ReadLine();
        }

        private static void Menu(Hero hero)
        {
            byte choice;
            do
            {
                Console.Clear();
                hero.Show();
                if (hero.GetBuff())
                {
                    hero.DeBuff();
                }
                if (hero.Get_state() == Hero.State.Live)
                {
                    Console.WriteLine(
                    "1. Увеличить уровень героя\n" +
                    "2. Обнулить уровень героя\n" +
                    "3. Убить героя\n" +
                    "4. Броня героя\n" +
                    "5. Использовать способность класса\n" +
                    "6. Нанести урон герою\n" +
                    "7. Выход");
                }
                else
                {
                    Console.WriteLine("3. Оживить героя");
                    Console.WriteLine("7. Выход");
                }
                try
                {
                    choice = Convert.ToByte(Console.ReadLine());
                }
                catch (Exception)
                {
                    choice = 0;
                };

                switch (choice)
                {
                    case 1:
                        hero++;
                        break;
                    case 2:
                        hero--;
                        break;
                    case 3:
                        hero.KillAlive();
                        break;
                    case 4:
                        hero.EquipArmor();
                        break;
                    case 5:
                        hero.Ability();
                        break;
                    case 6:
                        Console.Write("Введите количество урона - ");
                        link:
                        try
                        {
                            hero -= Convert.ToUInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            goto link;
                        }
                        break;
                    case 7:
                        StandartTheme();
                        break;
                    default:
                        Console.WriteLine("Пункт меню отсутствует!");
                        break;
                }
            } while (choice != 7);
        }
    }
}