using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin
{
    public static class Background
    {
        public static void DisplayMsg(string errmsg, int X, int Y)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
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
            Console.CursorVisible = true;
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
                        Console.ForegroundColor = ConsoleColor.Black;
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
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("\b \b");
                        inputChar.Pop();
                        Console.ResetColor();
                    }
                }
                else if (FILTERED.Count(x => chr == x) > 0) { }
                else if (inputChar.Count != 21)
                {
                    inputChar.Push(chr);
                    if (mask != '0')
                        WriteLine(mask);
                    else
                        WriteLine(chr);
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
                    WriteLine(chr);
                }
            }

            return new string(inputInteger.Reverse().ToArray());
        }
        public static void WriteLine(char value)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(value);
            Console.ResetColor();
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
            ConsoleKeyInfo cki;
            int cItem = 0;
            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter);

            while (true)
            {
                Console.SetCursorPosition(X, Y);
                WriteLine("                      ");
                Console.SetCursorPosition(X, Y);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 1) cItem = vs.Length - 1;
                        WriteLine(vs[cItem]);
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > vs.Length - 1) cItem = 1;
                        WriteLine(vs[cItem]);
                        break;
                    case ConsoleKey.Enter:
                        WriteLine(vs[cItem]);
                        return cItem;
                    default:
                        WriteLine(vs[cItem]);
                        break;
                }
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter);
            }
        }
    }
}
