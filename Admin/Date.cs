using System;

namespace Admin
{
    public class Date
    {
        private static ConsoleKeyInfo cki { get; set; }

        private static DateTime Minute(DateTime date, int X, int Y)
        {
            Console.SetCursorPosition(X + 16, Y);
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
                        date = date.AddMinutes(5);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.DownArrow:
                        if (date.AddMinutes(-5) > DateTime.Now)
                            date = date.AddMinutes(-5);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.LeftArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        date = Hour(date, X, Y);
                        return date;
                    case ConsoleKey.RightArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        date = Days(date, X, Y);
                        return date;
                }
                Console.SetCursorPosition(X + 16, Y);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                    cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow
                    && cki.Key != ConsoleKey.Enter);
            }
            return date;
        }
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
                        date = date.AddDays(1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.DownArrow:
                        if (date.AddDays(-1) > DateTime.Now)
                            date = date.AddDays(-1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.RightArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
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
                        date = date.AddMonths(1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.DownArrow:
                        if (date.AddMonths(-1) > DateTime.Now)
                            date = date.AddMonths(-1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.LeftArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        date = Days(date, X, Y);
                        return date;
                    case ConsoleKey.RightArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
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
                     cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
            while (cki.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(X, Y);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        date = date.AddYears(1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.DownArrow:
                        if (date.AddYears(-1) > DateTime.Now)
                            date = date.AddYears(-1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.LeftArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        date = Month(date, X, Y);
                        return date;
                    case ConsoleKey.RightArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        date = Hour(date, X, Y);
                        return date;
                }
                Console.SetCursorPosition(X + 10, Y);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                    cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
            }
            return date;
        }
        private static DateTime Hour(DateTime date, int X, int Y)
        {
            Console.SetCursorPosition(X + 13, Y);
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
                        date = date.AddHours(1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.DownArrow:
                        if (date.AddHours(-1) > DateTime.Now)
                            date = date.AddHours(-1);
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        break;
                    case ConsoleKey.LeftArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        date = Year(date, X, Y);
                        return date;
                    case ConsoleKey.RightArrow:
                        Background.WriteLine($"{date:dd/MMM/yyyy HH:mm}");
                        date = Minute(date, X, Y);
                        return date;
                }
                Console.SetCursorPosition(X + 13, Y);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                    cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
            }
            return date;
        }
    }
}
