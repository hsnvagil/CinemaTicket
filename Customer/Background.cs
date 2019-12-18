using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer
{
    public static class Background
    {
        public static void DisplayMsg(string errmsg, int X, int Y)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(X - (errmsg.Length / 2), Y);
            Console.WriteLine(errmsg);
            string msg = "";
            for (int i = 0; i < errmsg.Length - 1; i++)
            {
                if (i == errmsg.Length / 2 - 1)
                    msg += "Ok";
                else
                    msg += " ";
            }
            Console.SetCursorPosition(X - (msg.Length / 2), Y + 1);
            for (int i = 0; i < msg.Length; i++)
            {
                if (i != 0 && i != msg.Length - 1)
                {
                    if (msg[i + 1] == 'O' || msg[i] == 'O' || msg[i] == 'k' || msg[i - 1] == 'k')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(msg[i]);
            }
            Console.ReadLine();
            Console.ResetColor();

            string str = "";
            for (int i = 0; i < errmsg.Length; i++)
            {
                str += " ";
            }
            Console.SetCursorPosition(X - (errmsg.Length / 2), Y);
            Console.WriteLine(str);
            Console.SetCursorPosition(X - (errmsg.Length / 2), Y + 1);
            Console.WriteLine(str);
        }
        public static string InputString(string password, char mask = '0')
        {
            const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
            int[] FILTERED = { 0, 27, 9, 10 };

            char chr = (char)0;
            var inputChar = new Stack<char>();
            for (int i = 0; i < password.Length; i++)
                inputChar.Push(password[i]);

            while ((chr = Console.ReadKey(true).KeyChar) != ENTER)
            {
                if (chr == BACKSP)
                {
                    if (inputChar.Count > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("\b \b");
                        Console.ResetColor();
                        inputChar.Pop();
                    }
                }
                else if (chr == CTRLBACKSP)
                {
                    while (inputChar.Count > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("\b \b");
                        inputChar.Pop();
                        Console.ResetColor();
                    }
                }
                else if (FILTERED.Count(x => chr == x) > 0) { }
                else if (inputChar.Count != 22)
                {
                    inputChar.Push(chr);
                    if (mask != '0')
                        WriteLine(mask.ToString());
                    else
                        WriteLine(chr.ToString());
                }
            }

            Console.CursorVisible = false;
            return new string(inputChar.Reverse().ToArray());
        }
        public static string InputInteger(string integer)
        {
            const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;

            char chr = (char)0;
            var inputInteger = new Stack<char>();
            for (int i = 0; i < integer.Length; i++)
                inputInteger.Push(integer[i]);

            while ((chr = Console.ReadKey(true).KeyChar) != ENTER)
            {
                if (chr == BACKSP)
                {
                    if (inputInteger.Count > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\b \b");
                        Console.ResetColor();
                        inputInteger.Pop();
                    }
                }
                else if (chr == CTRLBACKSP)
                {
                    while (inputInteger.Count > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\b \b");
                        inputInteger.Pop();
                        Console.ResetColor();
                    }
                }
                else if (chr > 47 && chr < 58 && inputInteger.Count != 22)
                {
                    inputInteger.Push(chr);
                    WriteLine(chr.ToString());
                }
            }

            return new string(inputInteger.Reverse().ToArray());
        }
        public static void WriteLine(string value)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(value);
            Console.ResetColor();
        }
        public static int Arrow(string[] vs, int X, int Y)
        {
            ConsoleKeyInfo cki =
    new ConsoleKeyInfo('W', ConsoleKey.DownArrow, false, false, false);
            int cItem = 0;

            while (true)
            {
                Console.SetCursorPosition(X, Y);
                WriteLine("            ");
                Console.SetCursorPosition(X, Y);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cItem > 0)
                            cItem--;
                        WriteLine(vs[cItem]);
                        break;
                    case ConsoleKey.DownArrow:
                        if (cItem < vs.Length - 1)
                            cItem++;
                        WriteLine(vs[cItem]);
                        break;
                    case ConsoleKey.Enter:
                        WriteLine(vs[cItem]);
                        return cItem;
                }
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter);
            }
        }
    }
}
