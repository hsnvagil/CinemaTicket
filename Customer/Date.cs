using System;

namespace Customer
{
    public class Date
    {
        static private ConsoleKeyInfo cki { get; set; }
        public static DateTime Days(DateTime date, int X, int Y)
        {
            Console.SetCursorPosition(X + 1, Y);
            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
            while (cki.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(X, Y);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (date.AddDays(1) < DateTime.Now)
                            date = date.AddDays(1);
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        break;
                    case ConsoleKey.DownArrow:
                        date = date.AddDays(-1);
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        break;
                    case ConsoleKey.RightArrow:
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        date = Month(date, X, Y);
                        return date;
                }
                Console.SetCursorPosition(X + 1, Y);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
            }
            return date;
        }
        private static DateTime Month(DateTime date, int X, int Y)
        {
            Console.SetCursorPosition(X + 4, Y);
            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                     cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
            while (cki.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(X, Y);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (date.AddMonths(1) < DateTime.Now)
                            date = date.AddMonths(1);
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        break;
                    case ConsoleKey.DownArrow:
                        date = date.AddMonths(-1);
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        break;
                    case ConsoleKey.LeftArrow:
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        date = Days(date, X, Y);
                        return date;
                    case ConsoleKey.RightArrow:
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        date = Year(date, X, Y);
                        return date;
                }
                Console.SetCursorPosition(X + 4, Y);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                    cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
            }
            return date;
        }
        private static DateTime Year(DateTime date, int X, int Y)
        {
            Console.SetCursorPosition(X + 10, Y);
            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                     cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.Enter);
            while (cki.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(X, Y);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (date.AddYears(1) < DateTime.Now)
                            date = date.AddYears(1);
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        break;
                    case ConsoleKey.DownArrow:
                        date = date.AddYears(-1);
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        break;
                    case ConsoleKey.LeftArrow:
                        Background.WriteLine(String.Format("{0:dd-MMM-yyyy}", date));
                        date = Month(date, X, Y);
                        return date;
                }
                Console.SetCursorPosition(X + 10, Y);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                    cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.Enter);
            }
            return date;
        }
    }
}
