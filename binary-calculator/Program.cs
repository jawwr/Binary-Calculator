using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace binary_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<MenuItem> menu = new List<MenuItem>
            {
                new MenuItem {id = "AdditionalCode", description = "Перевод целых чисел в дополнительный код", select = true},
                new MenuItem {id = "AdditionOfIntegers", description = "Сложение целых (положительных и отрицательных) чисел с использованием дополнительного кода"},
                new MenuItem {id = "Exit", description = "exit"}
            };
            bool exit = false;
            do
            {
                ShowMenu(menu);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        MenuNext(menu);
                        break;
                    case ConsoleKey.UpArrow:
                        MenuPrev(menu);
                        break;
                    case ConsoleKey.Enter:
                        var select = menu.Find(item => item.select);
                        if (select.id == "Exit") exit = true;
                        else MenuEnter(select.id);
                        break;
                }
            } while (!exit);
        }
        public static void ShowMenu(List<MenuItem> menu)
        {
            Console.Clear();
            foreach (var item in menu)
            {
                Console.BackgroundColor = item.select 
                    ? ConsoleColor.DarkCyan 
                    : ConsoleColor.Black;
                Console.WriteLine(item.description);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        public static void MenuEnter(string id)
        {
            switch (id)
            {
                case "AdditionalCode":
                    AdditionalCode.AdditionalBinCode();
                    break;
                case "AdditionOfIntegers":
                    AdditionOfIntegers.Additation();
                    break;
            }
        }
        
        public static void MenuPrev(List<MenuItem> menu)
        {
            Console.Clear();
            MenuItem select = menu.Find(item => item.select);
            int selectindex = menu.IndexOf(select);
            menu[selectindex].select = false;
            selectindex = selectindex == 0 
                ? menu.Count - 1 
                : --selectindex;
            menu[selectindex].select = true;
        }
        
        public static void MenuNext(List<MenuItem> menu)
        {
            Console.Clear();
            MenuItem select = menu.Find(item => item.select);
            int selectindex = menu.IndexOf(select);
            menu[selectindex].select = false;
            selectindex = selectindex == menu.Count - 1 
                ? 0 
                : ++selectindex;
            menu[selectindex].select = true;
        }
    }
}