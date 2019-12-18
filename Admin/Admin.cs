using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Admin
{
    public class Admin
    {
        private string username;
        private string password;
        private string email;
        private string phone;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Admin()
        {

        }
        public void AdminPanel()
        {
            Console.Clear();
            Console.CursorVisible = false;

            ConsoleKeyInfo cki;
            WindowSize size = new WindowSize();

            int cItem = 0;
            string[] items = new string[] { " SIGN IN ", " SIGN UP " };
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);

            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkRed);
            rectangle.Draw();

            while (true)
            {
                int index = 0;

                for (index = 0; index < items.Length; index++)
                {
                    Y += 2;
                    Console.SetCursorPosition(size.Average - (items[index].Length / 2), Y);

                    if (index == cItem)
                        Background.WriteLine($"{items[index]}");
                    else
                        Console.Write($"{items[index]}");
                }
                Y = (size.Height / 2) - 4;

                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.Enter);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0)
                            cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1)
                            cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem == 0)
                            Login();
                        else if (cItem == 1)
                            Register();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void Register()
        {
            Console.Clear();
            ConsoleKeyInfo cki;
            WindowSize size = new WindowSize();

            int cItem = 0;
            string[] items = new string[] { " USERNAME ", " EMAIL ", " PHONE ", " PASSWORD ", " SIGN UP " };
            string[] variables = new string[] { "", "", "", "" };
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);


            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkRed);
            rectangle.Draw();

            while (true)
            {
                int index = 0;
                ;

                for (index = 0; index < items.Length; index++)
                {
                    Y += 2;
                    Console.SetCursorPosition(X, Y);
                    if (index != items.Length - 1)
                    {
                        if (index == cItem)
                            Background.WriteLine(items[index]);

                        else
                            Console.Write(items[index]);

                        Console.SetCursorPosition(size.Width - size.BWidth - 24, Y);
                        Background.WriteLine(" ");
                        if (index == 3)
                        {
                            for (int j = 0; j < variables[index].Length; j++)
                                Background.WriteLine("*");
                        }
                        else
                            Background.WriteLine(variables[index]);

                        Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[index].Length, Y);
                        for (int z = 0; z < 22 - variables[index].Length; z++)
                            Background.WriteLine(" ");
                    }
                    else
                    {
                        Console.SetCursorPosition(size.Average - (items[index].Length / 2), Y + 2);

                        if (index == cItem)
                            Background.WriteLine(items[index]);
                        else
                            Console.WriteLine(items[index]);
                    }
                }
                Y = (size.Height / 2) - (items.Length + 2);

                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter && cki.Key != ConsoleKey.Escape);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0)
                            cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1)
                            cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem != items.Length - 1)
                        {
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[cItem].Length, Y + (cItem * 2 + 2));
                            if (cItem == 3)
                                variables[cItem] = Background.InputString(variables[cItem], '*');
                            else
                                variables[cItem] = Background.InputString(variables[cItem]);
                        }
                        else
                        {
                            Console.SetCursorPosition(size.Average - 4, Y + 12);
                            Console.WriteLine(" Sign Up ");
                            if (Check.CheckUsername(variables[0], size.Average, Y + 14) && Check.CheckEmail(variables[1], size.Average, Y + 14) &&
                                Check.CheckPhone(variables[2], size.Average, Y + 14) && Check.CheckPassword(variables[3], size.Average, Y + 14))
                            {
                                string filePath = "admins.json";
                                Admin newAdmin = new Admin()
                                {
                                    UserName = variables[0],
                                    Email = variables[1],
                                    Phone = variables[2],
                                    Password = variables[3]
                                };
                                if (File.Exists(filePath))
                                {
                                    var jsonData = File.ReadAllText(filePath);
                                    var adminList = JsonConvert.DeserializeObject<List<Admin>>(jsonData)
                                        ?? new List<Admin>();
                                    adminList.Add(newAdmin);
                                    jsonData = JsonConvert.SerializeObject(adminList);
                                    File.WriteAllText(filePath, jsonData);
                                }
                                else
                                {
                                    var adminList = new List<Admin>();
                                    adminList.Add(newAdmin);
                                    var jsonData = JsonConvert.SerializeObject(adminList);
                                    File.WriteAllText(filePath, jsonData);
                                }
                                Background.DisplayMsg(" SUCCESSFULLY ", size.Average, Y + 14);
                                Login();
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        AdminPanel();
                        break;
                    default:
                        break;
                }
            }
        }
        private void Login()
        {
            Console.Clear();
            ConsoleKeyInfo cki;
            WindowSize size = new WindowSize();
            int cItem = 0;
            string[] items = new string[] { " USERNAME ", " PASSWORD ", " SIGN IN " };
            string[] variables = new string[] { "", "" };
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkRed);
            rectangle.Draw();

            while (true)
            {
                int index = 0;

                for (index = 0; index < items.Length; index++)
                {
                    Y += 2;
                    Console.SetCursorPosition(X, Y);
                    if (index != items.Length - 1)
                    {
                        if (index == cItem)
                            Background.WriteLine(items[index]);
                        else
                            Console.Write($"{items[index]}");

                        Console.SetCursorPosition(size.Width - size.BWidth - 24, Y);
                        Background.WriteLine(" ");
                        if (index == 1)
                        {
                            for (int j = 0; j < variables[index].Length; j++)
                                Background.WriteLine("*");
                        }
                        else
                            Background.WriteLine(variables[index]);

                        Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[index].Length, Y);
                        for (int z = 0; z < 22 - variables[index].Length; z++)
                            Background.WriteLine(" ");
                    }
                    else
                    {
                        Console.SetCursorPosition(size.Average - (items[index].Length / 2), Y + 2);

                        if (index == cItem)
                            Background.WriteLine(items[index]);
                        else
                            Console.WriteLine(items[index]);
                    }
                }
                Y = (size.Height / 2) - (items.Length + 2);
                Console.CursorVisible = false;
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0) cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem != items.Length - 1)
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[cItem].Length, Y + (cItem * 2 + 2));
                            if (cItem == 1)
                                variables[cItem] = Background.InputString(variables[cItem], '*');
                            else
                                variables[cItem] = Background.InputString(variables[cItem]);
                        }
                        else
                        {
                            UserName = variables[0];
                            Password = variables[1];
                            string filePath = "admins.json";
                            if (File.Exists(filePath))
                            {
                                var jsonData = File.ReadAllText(filePath);
                                var adminList = JsonConvert.DeserializeObject<List<Admin>>(jsonData)
                                    ?? new List<Admin>();

                                for (int y = 0; y < adminList.Count; y++)
                                {
                                    if (UserName == adminList[y].UserName && Password == adminList[y].Password)
                                    {
                                        AdminMenu();
                                        break;
                                    }
                                }
                            }
                            Console.SetCursorPosition(size.Average - 4, Y + 8);
                            Console.Write(" SIGN IN ");
                            Background.DisplayMsg(" INCORRECT USERNAME OR PASSWORD ", size.Average, Y + 10);
                        }
                        break;
                    case ConsoleKey.Escape:
                        AdminPanel();
                        break;
                    default:
                        break;
                }
            }
        }
        public void AdminMenu()
        {
            Console.Clear();
            ConsoleKeyInfo cki;
            int cItem = 0;
            string[] items = new string[] { " ADD TICKET ", " DELETE TICKET ", " BLOCK USER ", " CHANGE WINDOW SIZE ", " LOG OUT " };
            WindowSize size = new WindowSize();
            int Y = (size.Height / 2) - (items.Length + 2);
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkRed);
            rectangle.Draw();

            while (true)
            {
                int index;

                for (index = 0; index < items.Length; index++)
                {
                    Y += 2;
                    if (index != items.Length - 1)
                        Console.SetCursorPosition(size.Average - (items[index].Length / 2), Y);
                    else
                        Console.SetCursorPosition(size.Average - 1 - (items[index].Length / 2), Y + 2);
                    if (index == cItem)
                        Background.WriteLine($"{items[index]}");
                    else
                        Console.Write($"{items[index]}");
                }
                Y = (size.Height / 2) - (items.Length + 2);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0) cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem == 0)
                            AddTicket();
                        else if (cItem == 1)
                        {
                            string filePath = "movieTicket.json";
                            if (File.Exists(filePath))
                            {
                                var jsonData = File.ReadAllText(filePath);
                                var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData)
                                    ?? new List<Movie>();
                                if (movieList.Count == 0)
                                    Background.DisplayMsg(" SORRY, NO TICKET ", size.average, Y + 14);
                                else
                                    DelTicket();
                            }
                            else
                                Background.DisplayMsg(" SORRY, NO TICKET ", size.average, Y + 14);

                        }
                        else if (cItem == 2)
                        {
                            string filePath = @"C:\Users\ACER\source\repos\Customer\Customer\bin\Debug\customers.json";
                            if (File.Exists(filePath))
                            {
                                var jsonData = File.ReadAllText(filePath);
                                var customerList = JsonConvert.DeserializeObject<List<object>>(jsonData)
                                                    ?? new List<object>();
                                if (customerList.Count == 0)
                                    Background.DisplayMsg(" SORRY, NO CUSTOMER ", size.Average + 1, Y + 14);
                                else
                                    BlockUser();
                            }
                            else
                                Background.DisplayMsg(" SORRY, NO CUSTOMER ", size.Average, Y + 14);
                        }
                        else if (cItem == 3)
                            ChangeWindowSize();
                        else
                            AdminPanel();
                        break;
                }
            }
        }
        public void DelTicket()
        {
            WindowSize size = new WindowSize();
            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkRed);
            rectangle.Draw();

            string filePath = "movieTicket.json";
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData)
                    ?? new List<Movie>();

                ConsoleKeyInfo cki;
                int cItem = 0;
                int cItem2 = 0;
                string[] items = new string[]
            {
                "MOVIE NAME","MOVIE TYPE","MOVIE LANGUAGE", "MOVIE DURATION",
                "MOVIE PLACE","TICKET PRICE","MOVIE BEGIN",
            };
                int X = size.BWidth + 3;
                int Y = (size.Height / 2) - (items.Length + 2);

                while (true)
                {
                    object[] variables = new object[]
                {
                    movieList[cItem].Name, movieList[cItem].Type,movieList[cItem].Language,movieList[cItem].Duration,
                    movieList[cItem].Place,movieList[cItem].Price,movieList[cItem].Begin
                };
                    int index = 0;


                    for (index = 0; index < items.Length; index++)
                    {
                        Y += 2;
                        Console.SetCursorPosition(X, Y);

                        Console.Write($"{items[index]}");

                        if (index != 6)
                        {
                            Console.SetCursorPosition(size.Width - size.BWidth - 24, Y);
                            Background.WriteLine(" ");
                            Background.WriteLine($"{variables[index]}");

                            Console.CursorLeft = size.Width - size.BWidth - 23 + variables[index].ToString().Length;
                            for (int z = 0; z < 22 - variables[index].ToString().Length; z++)
                                Background.WriteLine(" ");
                        }

                        else
                        {
                            Console.SetCursorPosition(size.Width - size.BWidth - 24, Y);
                            Background.WriteLine(" ");
                            Background.WriteLine($"{variables[index]:dd/MMM/yyyy HH:mm}   ");

                            Console.CursorLeft = size.Width - size.BWidth - 23 + variables[index].ToString().Length;
                            for (int z = 0; z < 22 - variables[index].ToString().Length; z++)
                                Background.WriteLine(" ");
                        }
                    }
                    switch (cItem2)
                    {
                        case 0:
                            Console.SetCursorPosition(X, Y + 4);
                            Background.WriteLine(" PREV ");
                            Console.CursorLeft = size.Average - 3;
                            Console.Write(" DELETE ");
                            Console.CursorLeft = size.Width - size.BWidth - 24 + 17;
                            Console.Write(" NEXT ");
                            break;
                        case 1:
                            Console.SetCursorPosition(X, Y + 4); Console.Write(" PREV ");
                            Console.CursorLeft = size.Average - 3; Background.WriteLine(" DELETE ");
                            Console.CursorLeft = size.Width - size.BWidth - 24 + 17; Console.Write(" NEXT ");
                            break;
                        case 2:
                            Console.SetCursorPosition(X, Y + 4); Console.Write(" PREV ");
                            Console.CursorLeft = size.Average - 3; Console.Write(" DELETE ");
                            Console.CursorLeft = size.Width - size.BWidth - 24 + 17; Background.WriteLine(" NEXT ");
                            break;
                    }

                    Y = (size.Height / 2) - (items.Length + 2);
                    Console.CursorVisible = false;
                    do
                    {
                        cki = Console.ReadKey(true);
                    } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);
                    switch (cki.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            cItem2--;
                            if (cItem2 < 0) cItem2 = 2;
                            break;
                        case ConsoleKey.RightArrow:
                            cItem2++;
                            if (cItem2 > 2) cItem2 = 0;
                            break;
                        case ConsoleKey.Enter:
                            if (cItem2 == 0)
                            {
                                cItem--;
                                if (cItem < 0) cItem = movieList.Count - 1;
                            }
                            else if (cItem2 == 1)
                            {
                                movieList.RemoveAt(cItem);
                                jsonData = JsonConvert.SerializeObject(movieList);
                                File.WriteAllText(filePath, jsonData);

                                Background.DisplayMsg(" TICKET REMOVED! ", size.Average, Y + 18);
                                Console.Clear();
                                AdminMenu();
                            }
                            else if (cItem2 == 2)
                            {
                                cItem++;
                                if (cItem > movieList.Count - 1) cItem = 0;
                            }
                            break;
                        case ConsoleKey.Escape:
                            AdminMenu();
                            break;
                    }
                }
            }
        }
        public void BlockUser()
        {
            int lastWidth = Console.WindowWidth;
            int lastHeight = Console.WindowHeight;
            ConsoleKeyInfo cki;
            int cItem = 0;
            int index;
            Console.Clear();
            Console.SetWindowSize(77, 31);
            Point point = new Point(8, 9);
            ConsoleRectangle rectangle = new ConsoleRectangle(58, 11, point, ConsoleColor.DarkRed);
            rectangle.Draw();
            Console.SetCursorPosition(14, 10);
            Console.Write("Full Name");
            Console.SetCursorPosition(36, 10);
            Console.Write("Username");
            Console.SetCursorPosition(60, 10);
            Console.Write("Status");


            while (true)
            {
                string json = File.ReadAllText(@"C:\Users\ACER\source\repos\Customer\Customer\bin\Debug\customers.json");
                dynamic jsonObj = JsonConvert.DeserializeObject(json);

                if (cItem > 9)
                    index = cItem - 9;
                else
                    index = 0;


                int Y = 10;
                int max;

                if (jsonObj.Count > 10)
                    max = 10;
                else
                    max = jsonObj.Count;

                int o = 0;

                for (; o < max; index++, o++)
                {
                    Y += 1;
                    Console.SetCursorPosition(10, Y);
                    if (index == cItem)
                    {
                        Background.WriteLine($"{index + 1}");
                        Console.SetCursorPosition(14, Y);

                        Background.WriteLine($"{jsonObj[index]["Name"]} {jsonObj[index]["Surname"]}");

                        Console.SetCursorPosition(36, Y);
                        Background.WriteLine($"{jsonObj[index]["UserName"]}");

                        Console.SetCursorPosition(60, Y);
                        if (jsonObj[index]["isBlock"] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("BLOCK");
                            Console.WriteLine(" ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("ACTIVE");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.Write($"{index + 1}");
                        Console.SetCursorPosition(14, Y);

                        Console.Write($"{jsonObj[index]["Name"]} {jsonObj[index]["Surname"]}");

                        Console.SetCursorPosition(36, Y);
                        Console.Write($"{jsonObj[index]["UserName"]}");

                        Console.SetCursorPosition(60, Y);
                        if (jsonObj[index]["isBlock"] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("BLOCK ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("ACTIVE");
                            Console.ResetColor();
                        }
                    }
                }
                Console.CursorVisible = false;
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow &&
                cki.Key != ConsoleKey.Enter && cki.Key != ConsoleKey.Escape);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0)
                            cItem = jsonObj.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > jsonObj.Count - 1)
                            cItem = 0;
                        break;
                    case ConsoleKey.Escape:
                        Console.SetWindowSize(lastWidth, lastHeight);
                        AdminMenu();
                        break;
                    case ConsoleKey.Enter:
                        if (jsonObj[cItem].isBlock == true)
                        {
                            jsonObj[cItem]["isBlock"] = false;
                        }
                        else
                            jsonObj[cItem]["isBlock"] = true;

                        string output = JsonConvert.SerializeObject(jsonObj);
                        File.WriteAllText(@"C:\Users\ACER\source\repos\Customer\Customer\bin\Debug\customers.json", output);
                        break;
                }
            }

        }
        public void AddTicket()
        {
            Console.Clear();
            WindowSize size = new WindowSize();
            string[] items = new string[]
           {
                " MOVIE NAME "," MOVIE TYPE "," MOVIE LANGUAGE ", " MOVIE DURATION ",
                " MOVIE PLACE "," TICKET PRICE "," MOVIE BEGIN "," CREATE "
           };
            int X = size.BWidth + 3;
            int Y = (size.Height / 2) - (items.Length + 2);
            int cItem = 0;
            ConsoleKeyInfo cki;



            DateTime begin = new DateTime(2019, 9, 8, 18, 00, 00);

            object[] variables = new object[]
            {
                "","","","","","",new DateTime(2019, 9, 8,18,00,00),""
            };

            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkRed);
            rectangle.Draw();

            while (true)
            {
                int index = 0;


                for (index = 0; index < items.Length; index++)
                {
                    Y += 2;
                    Console.SetCursorPosition(X, Y);
                    if (index != items.Length - 1)
                    {
                        if (index == cItem)
                            Background.WriteLine(items[index]);

                        else
                            Console.Write($"{items[index]}");

                        Console.SetCursorPosition(size.Width - size.BWidth - 24, Y);
                        Background.WriteLine(" ");
                        if (index == 6)
                            Background.WriteLine($"{variables[index]:dd/MMM/yyyy HH:mm}   ");

                        else
                            Background.WriteLine($"{variables[index]}");
                        Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[index].ToString().Length, Y);

                        for (int z = 0; z < 22 - variables[index].ToString().Length; z++)
                            Background.WriteLine(" ");
                    }
                    else
                    {
                        Console.SetCursorPosition(size.Average - (items[index].Length / 2), Y + 1);

                        if (index == cItem)
                            Background.WriteLine(items[index]);
                        else
                            Console.WriteLine(items[index]);
                    }
                }
                Y = (size.Height / 2) - (items.Length + 2);
                Console.CursorVisible = false;
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter && cki.Key != ConsoleKey.Escape);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0) cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem != items.Length - 1)
                        {
                            if (cItem == 0 || cItem == 4 || cItem == 1 || cItem == 2)
                            {
                                Console.CursorVisible = true;
                                Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[cItem].ToString().Length, Y + (cItem * 2 + 2));
                                variables[cItem] = Background.InputString((string)variables[cItem]);
                            }
                            if (cItem == 3 || cItem == 5 || cItem == 7)
                            {
                                Console.CursorVisible = true;
                                Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[cItem].ToString().Length, Y + (cItem * 2 + 2));
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                variables[cItem] = Background.InputInteger((string)variables[cItem]);
                                Console.ResetColor();
                            }
                            else if (cItem == 6)
                            {
                                Console.CursorVisible = true;
                                begin = Date.Days(begin, size.Width - size.BWidth - 23, Y + (cItem * 2 + 2));
                                variables[cItem] = begin;
                            }
                        }
                        else
                        {
                            Int32.TryParse((string)variables[3], out int duration);
                            Int32.TryParse((string)variables[5], out int price);
                            Movie movie = new Movie()
                            {
                                Name = (string)variables[0],
                                Type = (string)variables[1],
                                Language = (string)variables[2],
                                Duration = duration,
                                Place = (string)variables[4],
                                Price = price,
                                Begin = (DateTime)variables[6],
                                BusySeats = new List<int>()
                            };

                            Console.SetCursorPosition(size.Average - 4, Y + 17);
                            Console.WriteLine(" CREATE ");

                            if (movie.Name.Length == 0 || movie.Place.Length == 0 || movie.Price == 0 || movie.Begin <= DateTime.Now
                                || movie.Language.Length == 0 || movie.Duration == 0 || movie.Type.Length == 0)
                            {
                                string msg = " INVALID TICKET DATA ";
                                Background.DisplayMsg(msg, size.Average, Y + 19);
                            }
                            else
                            {
                                if (File.Exists("movieTicket.json"))
                                {
                                    var jsonData = File.ReadAllText("movieTicket.json");
                                    var movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonData)
                                        ?? new List<Movie>();
                                    movieList.Add(movie);
                                    jsonData = JsonConvert.SerializeObject(movieList);
                                    File.WriteAllText("movieTicket.json", jsonData);
                                }
                                else
                                {
                                    var movieList = new List<Movie>();
                                    movieList.Add(movie);
                                    var jsonData = JsonConvert.SerializeObject(movieList);
                                    File.WriteAllText("movieTicket.json", jsonData);
                                }
                                string msg = " SUCCESSFULLY ";
                                Background.DisplayMsg(msg, size.Average, Y + 19);
                                AdminMenu();
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        AdminMenu();
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChangeWindowSize()
        {
            Console.Clear();
            ConsoleKeyInfo cki;
            int cItem = 0;
            string[] items = new string[] { " WINDOW WIDTH ", " WINDOW HEIGHT ", " CHANGE " };
            WindowSize size = new WindowSize();
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkRed);
            rectangle.Draw();

            string width = Console.WindowWidth.ToString();
            string height = Console.WindowHeight.ToString();

            string[] variables = new string[]
         {
                width,
                height
         };

            while (true)
            {

                int index = 0;

                for (index = 0; index < items.Length; index++)
                {
                    Y += 2;
                    Console.SetCursorPosition(X, Y);

                    if (index != items.Length - 1)
                    {
                        if (index == cItem)
                            Background.WriteLine(items[index]);

                        else
                            Console.Write(items[index]);

                        Console.SetCursorPosition(size.Width - size.BWidth - 24, Y);
                        Background.WriteLine(variables[index]);

                        Console.SetCursorPosition(size.Width - size.BWidth - 24 + variables[index].ToString().Length, Y);
                        for (int z = 0; z < 23 - variables[index].ToString().Length; z++)
                            Background.WriteLine(" ");
                    }


                    else
                    {
                        Console.SetCursorPosition(size.Average - (items[index].Length / 2), Y + 2);

                        if (index == cItem)
                            Background.WriteLine(items[index]);
                        else
                            Console.WriteLine(items[index]);
                    }

                }
                Y = (size.Height / 2) - (items.Length + 2);

                Console.CursorVisible = false;
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter && cki.Key != ConsoleKey.Escape);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0) cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem != items.Length - 1)
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(size.Width - size.BWidth - 24 + variables[cItem].ToString().Length, Y + (cItem * 2 + 2));

                            variables[cItem] = Background.InputInteger(variables[cItem]);
                        }
                        else
                        {
                            int w = Convert.ToInt32(variables[0]);
                            int h = Convert.ToInt32(variables[1]);

                            if (w < 160 && h < 44 && w > 60 && h > 24)
                            {
                                Console.SetCursorPosition(size.Average - 4, Y + 8);
                                Console.Write(" CREATE ");
                                Background.DisplayMsg(" SUCCESSFULLY ", size.Average, Y + 11);
                                Console.SetWindowSize(w, h);
                                AdminMenu();
                            }
                            else
                            {
                                Background.DisplayMsg(" INVALID SIZE ", size.Average - 1, Y + 11);
                            }

                        }
                        break;
                    case ConsoleKey.Escape:
                        AdminMenu();
                        break;
                }
            }
        }
    }
}
