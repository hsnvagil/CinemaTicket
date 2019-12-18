using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Customer
{
    public class Customer
    {
        private string name;
        private string surname;
        private string username;
        private string email;
        private string phone;
        private DateTime birthday;
        private string password;
        private bool isBlock;
        public List<Ticket> Tickets;
        public List<Card> UCard;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
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
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public bool IsBlock
        {
            get { return isBlock; }
            set { isBlock = value; }
        }

        public void CustomerPanel()
        {
            Console.Clear();
            WindowSize size = new WindowSize();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.CursorVisible = false;
            ConsoleKeyInfo cki;
            int cItem = 0;
            string[] items = new string[] { " SIGN IN ", " SIGN UP " };
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);
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
                        if (cItem < 0) cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem == 0)
                            SignIn();
                        else if (cItem == 1)
                            SignUp();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void SignUp()
        {
            WindowSize size = new WindowSize();
            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            string[] items = new string[]
           {
                " NAME ", " SURNAME ", " USERNAME "," EMAIL "," PHONE "," BIRTHDAY "," PASSWORD ", " SIGN UP "
           };
            int X = size.BWidth + 3;
            int Y = (size.Height / 2) - (items.Length + 2);
            int cItem = 0;
            ConsoleKeyInfo cki;


            object[] variables = new object[] { "", "", "", "", "", DateTime.Now.AddYears(-25), "" };

            DateTime birthday = DateTime.Now.AddYears(-25);

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
                        Background.WriteLine(" ");
                        if (index == 6)
                        {
                            for (int j = 0; j < variables[index].ToString().Length; j++)
                                Background.WriteLine("*");
                        }
                        else if (index == 5)
                        {
                            birthday = (DateTime)variables[index];
                            Background.WriteLine(String.Format("{0:dd-MMM-yyyy}          ", birthday));
                        }
                        else
                            Background.WriteLine(variables[index].ToString());

                        if (index != 5)
                        {
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[index].ToString().Length, Y);
                            for (int z = 0; z < 22 - variables[index].ToString().Length; z++)
                                Background.WriteLine(" ");
                        }
                        else
                        {
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[index].ToString().Length, Y);
                            for (int z = 0; z < 22 - variables[index].ToString().Length; z++)
                                Background.WriteLine(" ");
                        }
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
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[cItem].ToString().Length, Y + (cItem * 2 + 2));

                            if (cItem == 6)
                                variables[cItem] = Background.InputString(variables[cItem].ToString(), '*');
                            else if (cItem == 5)
                            {
                                Console.CursorVisible = true;
                                birthday = Date.Days(birthday, size.Width - size.BWidth - 23, Y + (cItem * 2 + 2));
                                variables[cItem] = birthday;
                                Console.CursorVisible = false;
                            }
                            else
                                variables[cItem] = Background.InputString(variables[cItem].ToString());
                        }
                        else
                        {
                            Console.SetCursorPosition(size.Average - 4, Y + 18);
                            Console.Write(" SIGN UP ");
                            if (Check.CheckName((string)variables[0], size.Average, Y + 20) && Check.CheckSurname((string)variables[1], size.Average, Y + 20) &&
                                Check.CheckBirthday((DateTime)variables[5], size.Average, Y + 20) && Check.CheckPassword((string)variables[6], size.Average, Y + 20) &&
                                Check.CheckUsername((string)variables[2], size.Average, Y + 20) && Check.CheckEmail((string)variables[3], size.Average, Y + 20)
                                && Check.CheckPhone((string)variables[4], size.Average, Y + 20)
                                )
                            {
                                Customer newCustomer = new Customer()
                                {
                                    Name = (string)variables[0],
                                    Surname = (string)variables[1],
                                    UserName = (string)variables[2],
                                    Email = (string)variables[3],
                                    Phone = (string)variables[4],
                                    Birthday = (DateTime)variables[5],
                                    Password = (string)variables[6],
                                    isBlock = false
                                };
                                string filePath = "customers.json";
                                if (File.Exists(filePath))
                                {

                                    var jsonData = File.ReadAllText(filePath);
                                    var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                                        ?? new List<Customer>();
                                    customerList.Add(newCustomer);
                                    jsonData = JsonConvert.SerializeObject(customerList);
                                    File.WriteAllText(filePath, jsonData);
                                }
                                else
                                {
                                    var customerList = new List<Customer>();
                                    customerList.Add(newCustomer);
                                    var jsonData = JsonConvert.SerializeObject(customerList);
                                    File.WriteAllText(filePath, jsonData);
                                }
                                Background.DisplayMsg(" SUCCESSFULLY ", size.Average, Y + 20);
                                SignIn();
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        CustomerPanel();
                        break;
                    default:
                        break;
                }
            }
        }
        private void SignIn()
        {
            ConsoleKeyInfo cki;
            WindowSize size = new WindowSize();
            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            int cItem = 0;
            string[] items = new string[] { " USERNAME ", " PASSWORD ", " SIGN IN " };
            string[] variables = new string[] { "", "" };
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);


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
                            string filePath = "customers.json";
                            if (File.Exists(filePath))
                            {
                                var jsonData = File.ReadAllText(filePath);
                                var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                                    ?? new List<Customer>();

                                for (int y = 0; y < customerList.Count; y++)
                                {
                                    if (UserName == customerList[y].UserName && Password == customerList[y].Password)
                                    {
                                        if (customerList[y].IsBlock == true)
                                        {
                                            Console.SetCursorPosition(size.Average - 4, Y + 8);
                                            Console.Write(" SIGN IN ");
                                            Background.DisplayMsg(" SORRY, YOU BLOCKED ", size.Average, Y + 10);
                                            break;
                                        }
                                        else if (customerList[y].IsBlock == false)
                                            CustomerMenu();
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(size.Average - 4, Y + 8);
                                        Console.Write(" SIGN IN ");
                                        Background.DisplayMsg(" INCORRECT USERNAME OR PASSWORD ", size.Average, Y + 10);
                                        //    break;
                                    }
                                }
                            }

                        }
                        break;
                    case ConsoleKey.Escape:
                        CustomerPanel();
                        break;
                    default:
                        break;
                }
            }
        }
        private void CustomerMenu()
        {
            ConsoleKeyInfo cki;
            int cItem = 0;
            string[] items = new string[] { " BUY TICKET ", " CUSTOM CABINET ", " CHANGE WINDOW SIZE ", " LOG OUT " };
            WindowSize size = new WindowSize();
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);
            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();
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
                            AllTicket();
                        else if (cItem == 1)
                            CustomCabinet();
                        else if (cItem == 2)
                            ChangeWindowSize();
                        else
                            CustomerPanel();
                        break;
                }
            }
        }
        private void CustomerInfo()
        {
            string name = "", surname = "", username = "", email = "", phone = "", password = "";
            string lName = "", lSurname = "", lUsername = "", lEmail = "", lPhone = "", lPassword = "";
            DateTime birthday = new DateTime();
            DateTime lBirthday = new DateTime();

            string filePath = "customers.json";
            var jsonData = File.ReadAllText(filePath);
            var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                ?? new List<Customer>();

            for (int i = 0; i < customerList.Count; i++)
            {
                if (UserName == customerList[i].UserName)
                {
                    name = customerList[i].Name; lName = customerList[i].Name;
                    surname = customerList[i].Surname; lSurname = customerList[i].Surname;
                    username = customerList[i].UserName; lUsername = customerList[i].UserName;
                    email = customerList[i].Email; lEmail = customerList[i].Email;
                    phone = customerList[i].Phone; lPhone = customerList[i].Phone;
                    birthday = customerList[i].Birthday; lBirthday = customerList[i].Birthday;
                    password = customerList[i].Password; lPassword = customerList[i].Password;
                }
            }


            ConsoleKeyInfo cki;
            int cItem = 0;


            WindowSize size = new WindowSize();
            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();
            string[] items = new string[]
            {
                " Name ", " Surname ", " Username "," Email "," Phone "," Birthday "," Password ", " Change "
            };
            object[] variables = new object[] { name, surname, username, email, phone, birthday, password };
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);

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
                        Background.WriteLine(" ");
                        if (index == 6)
                        {
                            for (int j = 0; j < variables[index].ToString().Length; j++)
                                Background.WriteLine("*");
                        }
                        else if (index == 5)
                        {
                            birthday = (DateTime)variables[index];
                            Background.WriteLine(String.Format("{0:dd/MMM/yyyy} ", birthday));
                        }
                        else
                            Background.WriteLine(variables[index].ToString());

                        if (index != 5)
                        {
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[index].ToString().Length, Y);
                            for (int z = 0; z < 22 - variables[index].ToString().Length; z++)
                                Background.WriteLine(" ");
                        }
                        else
                        {
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[index].ToString().Length - 9, Y);
                            for (int z = 0; z < 22 - variables[index].ToString().Length + 9; z++)
                                Background.WriteLine(" ");
                        }
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
                            Console.SetCursorPosition(size.Width - size.BWidth - 23 + variables[cItem].ToString().Length, Y + (cItem * 2 + 2));


                            if (cItem == 5)
                            {
                                Console.CursorVisible = true;
                                birthday = Date.Days(birthday, size.Width - size.BWidth - 23, Y + (cItem * 2 + 2));
                                variables[cItem] = birthday;
                            }
                            else if (cItem == 6)
                            {
                                Console.SetCursorPosition(size.Width - size.BWidth - 23, Y + (cItem * 2 + 2));
                                Background.WriteLine(variables[cItem].ToString());
                                variables[cItem] = Background.InputString(variables[cItem].ToString());
                            }
                            else
                                variables[cItem] = Background.InputString(variables[cItem].ToString());
                        }
                        else
                        {
                            if ((string)variables[0] == lName && (string)variables[1] == lSurname && (string)variables[2] == lUsername &&
                                (string)variables[3] == lEmail && (string)variables[4] == lPhone && (DateTime)variables[5] == lBirthday &&
                                (string)variables[6] == lPassword)
                            {
                                Console.SetCursorPosition(size.Average - 4, Y + 18);
                                Console.Write(" CHANGE ");
                                Background.DisplayMsg(" SORRY, NOTHING HAS CHANGED ", size.Average, Y + 20);
                            }

                            else if (Check.CheckName((string)variables[0], size.Average, Y + 20) && Check.CheckSurname((string)variables[1], size.Average, Y + 20) &&
                                Check.CheckBirthday((DateTime)variables[5], size.Average, Y + 20) && Check.CheckPassword((string)variables[6], size.Average, Y + 20) &&
                                Check.CheckUsername((string)variables[2], size.Average, Y + 20, lUsername) && Check.CheckEmail((string)variables[3], size.Average, Y + 20, lEmail)
                                && Check.CheckPhone((string)variables[4], size.Average, Y + 20, lPhone))
                            {
                                Customer chCustomer = new Customer()
                                {
                                    Name = (string)variables[0],
                                    Surname = (string)variables[1],
                                    UserName = (string)variables[2],
                                    Email = (string)variables[3],
                                    Phone = (string)variables[4],
                                    Birthday = (DateTime)variables[5],
                                    Password = (string)variables[6]
                                };
                                if (File.Exists(filePath))
                                {
                                    jsonData = File.ReadAllText(filePath);
                                    customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                                        ?? new List<Customer>();
                                    int i;
                                    for (i = 0; i < customerList.Count; i++)
                                    {
                                        if (lUsername == customerList[i].UserName)
                                        {
                                            break;
                                        }
                                    }
                                    customerList.RemoveAt(i);
                                    customerList.Add(chCustomer);
                                    jsonData = JsonConvert.SerializeObject(customerList);
                                    File.WriteAllText(filePath, jsonData);
                                }
                                else
                                {
                                    customerList = new List<Customer>();
                                    customerList.Add(chCustomer);
                                    jsonData = JsonConvert.SerializeObject(customerList);
                                    File.WriteAllText(filePath, jsonData);
                                }
                                Console.SetCursorPosition(size.Average - 4, Y + 18);
                                Console.Write(" Change ");
                                Background.DisplayMsg(" Successfully ", size.Average, Y + 20);
                                CustomCabinet();
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        CustomCabinet();
                        break;
                    default:
                        break;
                }
            }
        }
        private void CustomCabinet()
        {
            ConsoleKeyInfo cki;
            int cItem = 0;

            string[] items = new string[] { " MY INFO ", " MY CARD ", " MY TICKET " };
            WindowSize size = new WindowSize();
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);


            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();
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
                Y = (size.Height / 2) - (items.Length + 2);
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter);
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
                            CustomerInfo();
                        else if (cItem == 1)
                            CardMenu();
                        else
                            MyTicket();

                        break;
                    case ConsoleKey.Escape:
                        CustomerMenu();
                        break;
                }
            }
        }
        private void CardMenu()
        {
            ConsoleKeyInfo cki;
            int cItem = 0;
            int cItem2 = 0;

            WindowSize size = new WindowSize();
            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();

            string[] items = new string[] { " CREATE CARD ", " SHOW CARD " };
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);
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
                } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter);
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
                            CreateCard();
                        else if (cItem == 1)
                        {
                            string filePath = "customers.json";
                            int cListIndex = 0;
                            var jsonData = File.ReadAllText(filePath);
                            var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                                ?? new List<Customer>();

                            List<Card> cardList = new List<Card>();
                            for (int i = 0; i < customerList.Count; i++)
                            {
                                if (customerList[i].UserName == UserName && customerList[i].UCard != null)
                                {
                                    for (int j = 0; j < customerList[i].UCard.Count; j++)
                                        cardList.Add(customerList[i].UCard[j]);
                                    cListIndex = i;
                                }
                            }

                            if (cardList.Count == 0)
                                Background.DisplayMsg(" SORRY, YOU HAVE NOT CARD ", size.Average + 1, Y + 8);

                            else
                            {
                                int index2 = 0;
                                cItem2 = 0;
                                int lastWidth = Console.WindowWidth;
                                int lastHeight = Console.WindowHeight;
                                Console.Clear();
                                point = new Point(8, 9);
                                rectangle = new ConsoleRectangle(58, 14, point, ConsoleColor.DarkBlue);
                                rectangle.Draw();
                                Console.SetCursorPosition(21, 10);
                                Console.Write("Card Number");
                                Console.CursorLeft += 15;
                                Console.Write("Card Holder ");
                                while (cardList.Count != 0)
                                {
                                    if (cItem2 > 9)
                                        index2 = cItem2 - 9;
                                    else
                                        index2 = 0;
                                    Console.SetWindowSize(77, 31);

                                    int Y2 = 10;
                                    int max;
                                    if (cardList.Count > 10)
                                        max = 10;
                                    else
                                        max = cardList.Count;
                                    int o = 0;
                                    for (; o < max; index2++, o++)
                                    {
                                        Y2 += 1;
                                        Console.SetCursorPosition(10, Y2);
                                        if (index2 == cItem2)
                                        {
                                            Background.WriteLine($"{index2 + 1}");
                                            Console.Write("  ");
                                            Console.SetCursorPosition(21, Y2);

                                            Background.WriteLine(cardList[index2].CardNo);
                                            Console.CursorLeft += 7;
                                            Background.WriteLine($"{cardList[index2].FullName}");
                                            for (int i = 0; i < 19 - cardList[index2].FullName.Length; i++)
                                                Console.Write(" ");
                                        }
                                        else
                                        {
                                            Console.Write($"{index2 + 1}   ");
                                            Console.SetCursorPosition(21, Y2);

                                            Console.Write(cardList[index2].CardNo);
                                            Console.CursorLeft += 7;
                                            Console.Write($"{cardList[index2].FullName}");
                                            for (int i = 0; i < 19 - cardList[index2].FullName.Length; i++)
                                                Console.Write(" ");
                                        }
                                    }
                                    Console.CursorVisible = false;
                                    do
                                    {
                                        cki = Console.ReadKey(true);
                                    } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter
                                    && cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.Delete);


                                    switch (cki.Key)
                                    {
                                        case ConsoleKey.UpArrow:
                                            cItem2--;
                                            if (cItem2 < 0) cItem2 = cardList.Count - 1;
                                            break;
                                        case ConsoleKey.DownArrow:
                                            cItem2++;
                                            if (cItem2 > cardList.Count - 1) cItem2 = 0;
                                            break;
                                        case ConsoleKey.Enter:
                                            Console.SetWindowSize(lastWidth, lastHeight);
                                            DisplayCard(cardList[cItem2]);
                                            break;
                                        case ConsoleKey.Delete:
                                            Console.SetCursorPosition(18, 22);
                                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine(" ARE YOU SURE YOU WANT DELETE THIS CARD ? ");
                                            Console.ResetColor();
                                            int cItem3 = 1;
                                            string[] items3 = new string[] { "CANCEL", "DELETE" };
                                            int X2 = 31;
                                            bool check = true;
                                            while (check)
                                            {
                                                X2 = 31;
                                                for (int i = 0; i < items3.Length; i++)
                                                {
                                                    Console.SetCursorPosition(X2, 23);
                                                    if (cItem3 == i)
                                                        Background.WriteLine(items3[i]);
                                                    else
                                                        Console.WriteLine(items3[i]);
                                                    X2 += 7;
                                                }
                                                do
                                                {
                                                    cki = Console.ReadKey(true);
                                                } while (cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.Enter);
                                                switch (cki.Key)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        cItem3--;
                                                        if (cItem3 < 0) cItem3 = items3.Length - 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        cItem3++;
                                                        if (cItem3 > items3.Length - 1) cItem3 = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        check = false;
                                                        if (cItem3 == 1)
                                                        {
                                                            customerList[cListIndex].UCard.RemoveAt(cItem2);
                                                            cardList.RemoveAt(cItem2);
                                                            jsonData = JsonConvert.SerializeObject(customerList);
                                                            File.WriteAllText(filePath, jsonData);
                                                            CardMenu();
                                                        }
                                                        else
                                                        {
                                                            Console.SetCursorPosition(18, 22);
                                                            Console.WriteLine("                                        ");
                                                            Console.SetCursorPosition(31, 23);
                                                            Console.WriteLine("                                        ");
                                                        }
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            break;
                                        case ConsoleKey.Escape:
                                            Console.SetWindowSize(lastWidth, lastHeight);
                                            CardMenu();
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                if (cardList.Count == 0)
                                    Console.SetWindowSize(lastWidth, lastHeight);
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        CustomCabinet();
                        break;
                }
            }
        }
        private void CreateCard()
        {
            ConsoleKeyInfo cki;
            int cItem = 0;

            string[] items = new string[]
            {
                "Identy Number", "Name", "Surname","Phone", "Card Type", "Create"
            };
            WindowSize size = new WindowSize();
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);

            string[] variables = new string[] { "", "", "", "", "" };
            string jsonData;
            List<Customer> customerList;

            string filePath = "customers.json";
            if (File.Exists(filePath))
            {
                jsonData = File.ReadAllText(filePath);
                customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                    ?? new List<Customer>();

            }

            Console.Clear();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();

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
                            variables[cItem] = Background.InputString(variables[cItem]);
                        }
                        else
                        {
                            Console.SetCursorPosition(size.Average - 4, Y + 14);
                            Console.WriteLine(" Create ");
                            if (Check.CheckName(variables[1], size.Average, Y + 16) && Check.CheckSurname(variables[2], size.Average, Y + 16) &&
                                Check.CheckPhone(variables[3], size.Average, Y + 16) && Check.CheckIdenty(variables[0], size.Average, Y + 16))
                            {
                                Card newCard = new Card()
                                {
                                    FullName = variables[1] + ' ' + variables[2],
                                    CardNo = Card.CardNumberGenerator(),
                                    CVV = Card.CardCVVGenerator(),
                                    ExpDate = DateTime.Now.AddYears(1),
                                    CardType = variables[4],
                                };

                                filePath = "customers.json";
                                if (File.Exists(filePath))
                                {
                                    jsonData = File.ReadAllText(filePath);
                                    customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                                        ?? new List<Customer>();

                                    for (int y = 0; y < customerList.Count; y++)
                                    {
                                        if (UserName == customerList[y].UserName)
                                        {
                                            if (customerList[y].UCard == null)
                                                customerList[y].UCard = new List<Card>();

                                            customerList[y].UCard.Add(newCard);
                                        }
                                    }

                                    jsonData = JsonConvert.SerializeObject(customerList);
                                    File.WriteAllText(filePath, jsonData);
                                    Background.DisplayMsg(" Successfully ", size.Average, Y + 16);
                                    CardMenu();
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        CardMenu();
                        break;
                    default:
                        break;
                }
            }
        }
        private void DisplayCard(Card card)
        {
            ConsoleKeyInfo cki;
            string[] items = new string[] { "Full Name", "Card Type", "Card Number", "CVV", "Expiry Date" };
            string[] variables = new string[] { card.FullName, card.CardType, card.CardNo, card.CVV };
            WindowSize size = new WindowSize();
            int X = size.BWidth + 3, Y = (size.Height / 2) - (items.Length + 2);
            Console.Clear();

            int index = 0;
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();
            for (index = 0; index < items.Length; index++)
            {
                Y += 2;
                X = size.BWidth + 3;
                Console.SetCursorPosition(X, Y);
                if (index != 4)
                {
                    Console.Write(items[index]);
                    Console.SetCursorPosition(size.Width - size.BWidth - 20, Y);
                    Console.WriteLine(variables[index]);
                    Console.SetCursorPosition(X, Y);
                }
                else
                {
                    Console.Write(items[index]);
                    Console.SetCursorPosition(size.Width - size.BWidth - 20, Y);
                    Console.WriteLine("{0:y}", card.ExpDate);
                }
            }

            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.Escape);

            Console.Clear();
            point = new Point(8, 9);
            rectangle = new ConsoleRectangle(58, 11, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(26, 10);
            Console.Write("Card Number");
            Console.CursorLeft += 12;
            Console.Write("Card Holder ");
        }
        private void AllTicket()
        {
            ConsoleKeyInfo cki;
            Console.CursorVisible = false;
            string filePath = @"movieTicket.json";
            var jsonData = File.ReadAllText(filePath);
            var ticketList = JsonConvert.DeserializeObject<List<Movie>>(jsonData)
                ?? new List<Movie>();

            int lastWidth = 0;
            int lastHeight = 0;

            if (ticketList.Count == 0)
                CustomerMenu();
            else
            {
                lastWidth = Console.WindowWidth;
                lastHeight = Console.WindowHeight;
                Console.SetWindowSize(85, 31);
            }

            int cItem = 0;
            int index = 0;

            Console.Clear();
            Point point = new Point(4, 7);
            ConsoleRectangle rectangle = new ConsoleRectangle(75, 15, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            var def = ticketList;

            while (ticketList.Count != 0)
            {
                label1:
                if (cItem > 9)
                    index = cItem - 9;
                else
                    index = 0;

                int Y = 8;
                int max;

                if (ticketList.Count > 10)
                    max = 10;
                else
                    max = ticketList.Count;
                int o = 0;

                for (; o < max; o++, index++)
                {
                    Y++;
                    Console.SetCursorPosition(6, Y);

                    if (cItem == ticketList.Count)
                    {
                        int z = 9;
                        int maxx;
                        if (ticketList.Count > 10)
                            maxx = 10;
                        else
                            maxx = ticketList.Count;
                        for (int k = 0; k < maxx; k++, z++)
                        {
                            Console.SetCursorPosition(6, z);
                            Console.Write($"{k + 1}  ");
                            Console.SetCursorPosition(10, z);

                            Console.Write(ticketList[k].Name);

                            for (int i = 0; i < 24 - ticketList[k].Name.Length; i++)
                                Console.Write(" ");

                            Console.CursorLeft = 35;
                            Console.Write(ticketList[k].Place);
                            for (int i = 0; i < 19 - ticketList[k].Place.Length; i++)
                                Console.Write(" ");
                            Console.CursorLeft = 55;
                            Console.Write(ticketList[k].Price.ToString() + "AZN");
                            if (ticketList[k].Price.ToString().Length == 1)
                                Console.Write(" ");
                            Console.CursorLeft = 66;
                            Console.Write(String.Format("{0:dd/MMM} {0:t}", ticketList[k].Begin));
                        }
                        Console.SetCursorPosition(5, 21);
                        Background.WriteLine(" SORT ");
                    }
                    else if (index == cItem)
                    {
                        Background.WriteLine($"{index + 1}");
                        Console.Write("  ");
                        Console.SetCursorPosition(10, Y);


                        Background.WriteLine(ticketList[index].Name);
                        for (int i = 0; i < 24 - ticketList[index].Name.Length; i++)
                            Console.Write(" ");

                        Console.CursorLeft = 35;
                        Background.WriteLine(ticketList[index].Place);
                        for (int i = 0; i < 19 - ticketList[index].Place.Length; i++)
                            Console.Write(" ");
                        Console.CursorLeft = 55;
                        Background.WriteLine(ticketList[index].Price.ToString() + "AZN");
                        if (ticketList[index].Price.ToString().Length == 1)
                            Console.Write(" ");
                        Console.CursorLeft = 66;
                        Background.WriteLine(String.Format("{0:dd/MMM} {0:t}", ticketList[index].Begin));
                        Console.SetCursorPosition(5, 21);
                        Console.Write(" SORT ");
                    }
                    else
                    {
                        Console.Write($"{index + 1}  ");
                        Console.SetCursorPosition(10, Y);

                        Console.Write(ticketList[index].Name);

                        for (int i = 0; i < 24 - ticketList[index].Name.Length; i++)
                            Console.Write(" ");

                        Console.CursorLeft = 35;
                        Console.Write(ticketList[index].Place);
                        for (int i = 0; i < 19 - ticketList[index].Place.Length; i++)
                            Console.Write(" ");
                        Console.CursorLeft = 55;
                        Console.Write(ticketList[index].Price.ToString() + "AZN");
                        if (ticketList[index].Price.ToString().Length == 1)
                            Console.Write(" ");
                        Console.CursorLeft = 66;
                        Console.Write(String.Format("{0:dd/MMM} {0:t}", ticketList[index].Begin));

                        Console.SetCursorPosition(5, 21);
                        Console.Write(" SORT ");
                    }
                }

                Console.CursorVisible = false;
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter
                && cki.Key != ConsoleKey.Escape);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0) cItem = ticketList.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > ticketList.Count) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem != ticketList.Count)
                        {
                            Console.SetWindowSize(lastWidth, lastHeight);
                            EventDescription(ticketList[cItem]);
                        }
                        else if (cItem == ticketList.Count)
                        {
                            Console.OutputEncoding = Encoding.Unicode;
                            string[] a = new string[] { " ▼  DEFAULT  ", " ▼  NAME   ▲ ", " ▼  PLACE  ▲ ", " ▼  BEGIN  ▲ ", "    PRICE  ▲ " };
                            int c = Background.Arrow(a, 14, 21);
                            if (c == 1)
                            {
                                ticketList = ticketList.OrderBy(d => d.Name).ToList();

                                Console.SetCursorPosition(14, 21);
                                Console.WriteLine("               ");
                                goto label1;
                            }
                            if (c == 2)
                            {
                                ticketList = ticketList.OrderBy(d => d.Place).ToList();

                                Console.SetCursorPosition(14, 21);
                                Console.WriteLine("               ");
                                goto label1;
                            }
                            if (c == 3)
                            {
                                ticketList = ticketList.OrderBy(d => d.Begin).ToList();

                                Console.SetCursorPosition(14, 21);
                                Console.WriteLine("               ");
                                goto label1;
                            }
                            if (c == 4)
                            {
                                ticketList = ticketList.OrderBy(d => d.Price).ToList();

                                Console.SetCursorPosition(14, 21);
                                Console.WriteLine("               ");
                                goto label1;
                            }
                            else
                            {
                                ticketList = def;
                                Console.SetCursorPosition(14, 21);
                                Console.WriteLine("               ");
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.SetWindowSize(lastWidth, lastHeight);
                        CustomerMenu();
                        break;
                }
            }
        }
        private void EventDescription(Movie movie)
        {
            ConsoleKeyInfo cki;
            string[] items = new string[] { "MOVIE NAME", "MOVIE TYPE", "MOVIE LANGUAGE", "MOVIE PLACE", "MOVIE BEGIN TIME", "MOVIE DURATION", "TICKET PRICE", " BUY TICKET " };
            object[] variables = new object[] { movie.Name, movie.Type, movie.Language, movie.Place, movie.Begin, movie.Duration, movie.Price };
            WindowSize size = new WindowSize();
            int X, Y = (size.Height / 2) - (items.Length + 2);
            Console.Clear();

            int index;
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();
            for (index = 0; index < items.Length; index++)
            {
                Y += 2;
                X = size.BWidth + 3;
                Console.SetCursorPosition(X, Y);
                if (index != items.Length - 1)
                {
                    if (index != 4 && index != 6)
                    {
                        Console.Write(items[index]);
                        Console.SetCursorPosition(size.Width - size.BWidth - 22, Y);
                        Console.Write(variables[index].ToString());
                    }
                    else if (index == 6)
                    {
                        Console.Write(items[index]);
                        Console.SetCursorPosition(size.Width - size.BWidth - 22, Y);
                        Console.Write(variables[index].ToString() + "AZN");
                    }
                    else
                    {
                        Console.Write(items[index]);
                        Console.SetCursorPosition(size.Width - size.BWidth - 22, Y);
                        Console.Write(String.Format("{0:dd/MMM} {0:t}", variables[index]));
                    }
                    if (index == 5)
                        Console.WriteLine(" minutes");

                    else
                        Console.WriteLine();

                    Console.SetCursorPosition(X, Y);
                }
                else
                {
                    Console.SetCursorPosition(size.Average - (items[index].Length / 2), Y + 1);
                    Background.WriteLine(items[index]);
                }
            }


            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.Enter);

            if (cki.Key == ConsoleKey.Enter)
                SelectSeat(movie);
            else
                AllTicket();
        }
        private void SelectSeat(Movie movie)
        {
            Console.Clear();
            List<int> busy = new List<int>();
            List<int> choice = new List<int>();
            if (movie.BusySeats != null)
            {
                for (int i = 0; i < movie.BusySeats.Count; i++)
                    busy.Add(movie.BusySeats[i]);
            }
            int lastWidth = Console.WindowWidth;
            int lastHeight = Console.WindowHeight;
            Console.SetWindowSize(90, 30);
            Console.Clear();
            int aWidth = 90 - (8 * 2) - 1;
            int aHeight = 30 - (5 * 2) - 1;
            Point point = new Point(8, 4);
            ConsoleRectangle rectangle = new ConsoleRectangle(aWidth, aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            ConsoleKeyInfo cki2;
            string[] seats = new string[106];
            int x, y;
            int cItem = 0;
            while (busy.Contains(cItem))
                cItem++;

            for (int i = 0; i < 106; i++)
            {
                if (i == 105)
                    seats[i] = " SELECT SEAT ";
                else
                    seats[i] = "█";
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(22, 7);
            Console.Write("E");
            Console.SetCursorPosition(22, 9);
            Console.Write("D");
            Console.SetCursorPosition(22, 11);
            Console.Write("C");
            Console.SetCursorPosition(22, 13);
            Console.Write("B");
            Console.SetCursorPosition(22, 15);
            Console.Write("A");
            Console.ResetColor();
            while (true)
            {
                int i;
                x = 25; y = 7;
                Console.SetCursorPosition(x, y);
                for (i = 0; i < seats.Length; i++)
                {
                    if (i == 21 || i == 42 || i == 63 || i == 84)
                    {
                        y += 2;
                        Console.SetCursorPosition(x, y);
                    }
                    if (i == 105)
                    {
                        Console.SetCursorPosition(39, 17);
                        if (i == cItem)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(seats[i]);
                            Console.ResetColor();
                        }
                        else
                            Console.Write(seats[i]);
                    }
                    else if (busy.Contains(i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(seats[i]);
                        Console.ResetColor();
                    }
                    else if (choice.Contains(i))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        if (i == cItem)
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(seats[i]);
                        Console.ResetColor();
                    }
                    else if (i == cItem)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(seats[i]);
                        Console.ResetColor();
                    }

                    else
                        Console.Write(seats[i]);
                    Console.Write(" ");
                }
                do
                {
                    cki2 = Console.ReadKey(true);
                } while (cki2.Key != ConsoleKey.LeftArrow && cki2.Key != ConsoleKey.RightArrow &&
                cki2.Key != ConsoleKey.UpArrow && cki2.Key != ConsoleKey.DownArrow && cki2.Key != ConsoleKey.Enter &&
                cki2.Key != ConsoleKey.Escape);

                switch (cki2.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (cItem < 105)
                            cItem++;
                        while (busy.Contains(cItem))
                            cItem++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cItem > 0)
                            cItem--;
                        while (busy.Contains(cItem))
                            cItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cItem < 84)
                        {
                            cItem += 21;
                            while (busy.Contains(cItem))
                            {
                                cItem += 21;
                            }
                        }
                        else
                            cItem = 105;
                        break;
                    case ConsoleKey.UpArrow:
                        int last = cItem;
                        if (cItem == 105)
                        {
                            cItem -= 11;
                            while (busy.Contains(cItem))
                            {
                                cItem -= 21;
                                if (cItem < 0)
                                {
                                    cItem = last;
                                    break;
                                }
                            }
                        }
                        else if (cItem > 20)
                        {
                            cItem -= 21;
                            while (busy.Contains(cItem))
                            {
                                cItem -= 21;
                                if (cItem < 0)
                                {
                                    cItem = last;
                                    break;
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (cItem == 105)
                        {
                            if (choice.Count == 0)
                                Background.DisplayMsg(" Please select seat ", 46, 19);
                            else
                                BuyTicket(movie, choice);
                        }
                        if (choice.Contains(cItem))
                            choice.Remove(cItem);
                        else if (cItem != 105)
                            choice.Add(cItem);
                        break;
                    case ConsoleKey.Escape:
                        Console.SetWindowSize(lastWidth, lastHeight);
                        AllTicket();
                        break;
                }
            }
        }
        private void BuyTicket(Movie movie, List<int> seat)
        {
            string Date = $"{movie.Begin:ddd, MMM d, yyyy}";
            string Time = String.Format("{0:t}", movie.Begin);


            Console.Clear();
            ConsoleKeyInfo cki;
            Point point = new Point(1, 2);
            ConsoleRectangle rectangle = new ConsoleRectangle(25, 10, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(1 + 25 - UserName.Length - 2, 2 + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();
            int cItem = 0, cItem2 = 0;

            while (true)
            {
                string Row = "";
                int Seat;
                if (seat[cItem] < 21)
                {
                    Row = "E";
                    Seat = seat[cItem] + 1;
                }
                else if (seat[cItem] < 42)
                {
                    Row = "D";
                    Seat = seat[cItem] - 20;
                }
                else if (seat[cItem] < 63)
                {
                    Row = "C";
                    Seat = seat[cItem] - 41;
                }
                else if (seat[cItem] < 84)
                {
                    Row = "B";
                    Seat = seat[cItem] - 62;
                }
                else
                {
                    Row = "A";
                    Seat = seat[cItem] - 83;
                }

                Console.SetCursorPosition(3, 3);
                Console.Write(movie.Name);
                Console.SetCursorPosition(3, 5);
                Console.Write(movie.Place);
                Console.SetCursorPosition(3, 8);
                Console.Write($"Row:{Row} / Seat:{Seat}  ");
                Console.SetCursorPosition(20, 8);
                Console.Write(movie.Price + "AZN");
                Console.SetCursorPosition(3, 11);
                Console.Write(Date + " " + Time);

                Console.SetCursorPosition(33, 5);
                Console.Write("Tickets Count " + seat.Count);
                Console.SetCursorPosition(33, 7);
                Console.Write("Tickets Price " + movie.Price + "AZN");
                Console.SetCursorPosition(33, 9);
                Console.Write("Total " + seat.Count * movie.Price + "AZN");

                switch (cItem2)
                {
                    case 0:
                        Console.SetCursorPosition(1, 14);
                        Background.WriteLine(" PREV ");
                        Console.SetCursorPosition(8, 14);
                        Console.Write(" BUY TICKET ");
                        Console.SetCursorPosition(21, 14);
                        Console.WriteLine(" NEXT ");
                        break;
                    case 1:
                        Console.SetCursorPosition(1, 14);
                        Console.Write(" PREV ");
                        Console.SetCursorPosition(8, 14);
                        Background.WriteLine(" BUY TICKET ");
                        Console.SetCursorPosition(21, 14);
                        Console.WriteLine(" NEXT ");
                        break;
                    case 2:
                        Console.SetCursorPosition(1, 14);
                        Console.Write(" PREV ");
                        Console.SetCursorPosition(8, 14);
                        Console.Write(" BUY TICKET ");
                        Console.SetCursorPosition(21, 14);
                        Background.WriteLine(" NEXT ");
                        break;
                }
                Console.CursorVisible = false;
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.LeftArrow &&
                cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);

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
                            if (cItem < 0) cItem = seat.Count - 1;
                        }
                        else if (cItem2 == 1)
                        {
                            bool check = true;
                            int k = 0;
                            while (check)
                            {
                                ConsoleKeyInfo keyInfo;
                                Console.SetCursorPosition(2, 16);
                                Console.WriteLine("PAYMENT METHOD");
                                if (k == 0)
                                {
                                    Background.WriteLine(" CARD \n");
                                    Console.Write(" OTHER ");
                                }
                                else
                                {
                                    Console.WriteLine(" CARD ");
                                    Background.WriteLine(" OTHER ");
                                }
                                do
                                {
                                    keyInfo = Console.ReadKey(true);
                                } while (keyInfo.Key != ConsoleKey.DownArrow && keyInfo.Key != ConsoleKey.UpArrow &&
                                keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

                                switch (keyInfo.Key)
                                {
                                    case ConsoleKey.DownArrow:
                                        k++;
                                        if (k > 1) k = 0;
                                        break;
                                    case ConsoleKey.UpArrow:
                                        k--;
                                        if (k < 0) k = 1;
                                        break;
                                    case ConsoleKey.Enter:
                                        if (k == 0)
                                        {
                                            string filePath = "customers.json";
                                            int count = 0;
                                            var jsonData = File.ReadAllText(filePath);
                                            var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                                                ?? new List<Customer>();

                                            List<Card> cardList = new List<Card>();
                                            for (int i = 0; i < customerList.Count; i++)
                                            {
                                                if (customerList[i].UserName == UserName && customerList[i].UCard != null)
                                                {
                                                    count++;
                                                    break;
                                                }
                                            }

                                            if (count == 0)
                                                Background.DisplayMsg(" SORRY, YOU HAVE NOT CARD ", 61, 20);

                                            else
                                                CardMethod(movie, seat);
                                        }
                                        break;
                                    case ConsoleKey.Escape:
                                        check = false;
                                        break;
                                }
                            }
                        }
                        else if (cItem2 == 2)
                        {
                            cItem++;
                            if (cItem > seat.Count - 1) cItem = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        EventDescription(movie);
                        break;
                }
            }
        }
        private void CardMethod(Movie movie, List<int> seat)
        {
            ConsoleKeyInfo cki;
            string filePath = "customers.json";
            var jsonData = File.ReadAllText(filePath);
            var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                ?? new List<Customer>();

            List<Card> cardList = new List<Card>();
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].UserName == UserName && customerList[i].UCard != null)
                {
                    for (int j = 0; j < customerList[i].UCard.Count; j++)
                        cardList.Add(customerList[i].UCard[j]);
                }
            }

            int index;
            int cItem = 0;
            int lastWidth = Console.WindowWidth;
            int lastHeight = Console.WindowHeight;
            Console.Clear();
            Point point = new Point(8, 9);
            ConsoleRectangle rectangle = new ConsoleRectangle(58, 11, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(26, 10);
            Console.Write("CARD NUMBER");
            Console.CursorLeft += 12;
            Console.Write("CARD HOLDER ");
            while (cardList.Count != 0)
            {
                if (cItem > 9)
                    index = cItem - 9;
                else
                    index = 0;
                Console.SetWindowSize(77, 31);

                int Y2 = 10;
                int max;
                if (cardList.Count > 10)
                    max = 10;
                else
                    max = cardList.Count;
                int o = 0;
                for (; o < max; index++, o++)
                {
                    Y2 += 1;
                    Console.SetCursorPosition(10, Y2);
                    if (index == cItem)
                    {
                        Background.WriteLine($"{index + 1}");
                        Console.Write("  ");
                        Console.SetCursorPosition(21, Y2);

                        Background.WriteLine(cardList[index].CardNo);
                        Console.CursorLeft += 7;
                        Background.WriteLine($"{cardList[index].FullName}");
                        for (int i = 0; i < 19 - cardList[index].FullName.Length; i++)
                            Console.Write(" ");
                    }
                    else
                    {
                        Console.Write($"{index + 1}   ");
                        Console.SetCursorPosition(21, Y2);

                        Console.Write(cardList[index].CardNo);
                        Console.CursorLeft += 7;
                        Console.Write($"{cardList[index].FullName}");
                        for (int i = 0; i < 19 - cardList[index].FullName.Length; i++)
                            Console.Write(" ");
                    }
                }
                Console.CursorVisible = false;
                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.Enter
                && cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.Delete);


                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        cItem--;
                        if (cItem < 0) cItem = cardList.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > cardList.Count - 1) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        {
                            Console.SetCursorPosition(18, 22);
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" ARE YOU SURE YOU WANT TO DO THIS ? ");
                            Console.ResetColor();
                            int cItem3 = 1;
                            string[] items3 = new string[] { "CANCEL", "CONFIRM" };
                            int X2 = 31;
                            bool check = true;
                            while (check)
                            {
                                X2 = 31;
                                for (int i = 0; i < items3.Length; i++)
                                {
                                    Console.SetCursorPosition(X2, 23);
                                    if (cItem3 == i)
                                        Background.WriteLine(items3[i]);
                                    else
                                        Console.WriteLine(items3[i]);
                                    X2 += 7;
                                }
                                do
                                {
                                    cki = Console.ReadKey(true);
                                } while (cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.Enter);
                                switch (cki.Key)
                                {
                                    case ConsoleKey.RightArrow:
                                        cItem3--;
                                        if (cItem3 < 0) cItem3 = items3.Length - 1;
                                        break;
                                    case ConsoleKey.LeftArrow:
                                        cItem3++;
                                        if (cItem3 > items3.Length - 1) cItem3 = 0;
                                        break;
                                    case ConsoleKey.Enter:
                                        check = false;
                                        if (cItem3 == 1)
                                        {
                                            for (int z = 0; z < seat.Count; z++)
                                            {
                                                string Row;
                                                int Seat;
                                                if (seat[z] < 21)
                                                {
                                                    Row = "E";
                                                    Seat = seat[cItem] + 1;
                                                }
                                                else if (seat[z] < 42)
                                                {
                                                    Row = "D";
                                                    Seat = seat[z] - 20;
                                                }
                                                else if (seat[z] < 63)
                                                {
                                                    Row = "C";
                                                    Seat = seat[z] - 41;
                                                }
                                                else if (seat[z] < 84)
                                                {
                                                    Row = "B";
                                                    Seat = seat[z] - 62;
                                                }
                                                else
                                                {
                                                    Row = "A";
                                                    Seat = seat[z] - 83;
                                                }
                                                Ticket ticket = new Ticket()
                                                {
                                                    Name = movie.Name,
                                                    Price = movie.Price.ToString(),
                                                    Row = Row,
                                                    Seat = Seat.ToString(),
                                                    PaymentMethod = "card",
                                                    Place = movie.Place,
                                                    Begin = movie.Begin
                                                };
                                                for (int i = 0; i < customerList.Count; i++)
                                                {
                                                    if (customerList[i].Tickets == null)
                                                        customerList[i].Tickets = new List<Ticket>();

                                                    customerList[i].Tickets.Add(ticket);
                                                }
                                            }
                                            jsonData = JsonConvert.SerializeObject(customerList);
                                            File.WriteAllText(filePath, jsonData);

                                            filePath = @"movieTicket.json";
                                            jsonData = File.ReadAllText(filePath);
                                            var ticketList = JsonConvert.DeserializeObject<List<Movie>>(jsonData)
                                                ?? new List<Movie>();

                                            for (int i = 0; i < ticketList.Count; i++)
                                            {
                                                if (ticketList[i].Name == movie.Name)
                                                {
                                                    for (int j = 0; j < seat.Count; j++)
                                                        ticketList[i].BusySeats.Add(seat[j]);
                                                }
                                            }

                                            jsonData = JsonConvert.SerializeObject(ticketList);
                                            File.WriteAllText(filePath, jsonData);

                                            Console.SetCursorPosition(18, 22);
                                            Console.WriteLine("                                        ");
                                            Console.SetCursorPosition(31, 23);
                                            Console.WriteLine("                                        ");
                                            Console.SetCursorPosition(18, 22);
                                            Background.DisplayMsg(" YOU BOUGHT TICKET ", 38, 22);
                                            MyTicket();
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(18, 22);
                                            Console.WriteLine("                                        ");
                                            Console.SetCursorPosition(31, 23);
                                            Console.WriteLine("                                        ");
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.SetWindowSize(lastWidth, lastHeight);
                        CardMenu();
                        break;
                    default:
                        break;
                }
            }

            if (cardList.Count == 0)
                Console.SetWindowSize(lastWidth, lastHeight);
        }
        private void MyTicket()
        {
            Console.Clear();
            WindowSize size = new WindowSize();
            Point point = new Point(size.BWidth, size.BHeight);
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
            rectangle.Draw();
            Console.SetCursorPosition(size.BWidth + size.aWidth - UserName.Length - 2, size.BHeight + 1);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" {UserName} ");
            Console.ResetColor();
            Console.CursorVisible = false;
            ConsoleKeyInfo cki;
            int cItem = 0;
            string[] items = new string[] { " ACTIVE TICKET ", " DEACTIVE TICKET " };
            int Y = (size.Height / 2) - (items.Length + 2);
            while (true)
            {
                int index;
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
                        if (cItem < 0) cItem = items.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cItem++;
                        if (cItem > items.Length - 1) cItem = 0;
                        break;
                    case ConsoleKey.Enter:
                        string filePath = "customers.json";
                        var jsonData = File.ReadAllText(filePath);
                        var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                            ?? new List<Customer>();


                        if (cItem == 0)
                        {
                            for (int i = 0; i < customerList.Count; i++)
                            {
                                if (UserName == customerList[i].UserName)
                                {
                                    if (customerList[i].Tickets == null || customerList[i].Tickets.Count == 0)
                                        Background.DisplayMsg(" NO ACTIVE TICKET ", size.Average, Y + 8);
                                    else if (customerList[i].Tickets.Count != 0)
                                    {
                                        for (int j = 0; j < customerList[i].Tickets.Count; j++)
                                        {
                                            if (customerList[i].Tickets[j].Begin > DateTime.Now)
                                                TicketDisplay(true);

                                            else
                                            {
                                                Background.DisplayMsg(" NO ACTIVE TICKET ", size.Average, Y + 8);
                                                break;
                                            }
                                        }
                                    }

                                }
                            }
                        }
                        else if (cItem == 1)
                        {

                            for (int i = 0; i < customerList.Count; i++)
                            {
                                if (UserName == customerList[i].UserName)
                                {
                                    if (customerList[i].Tickets == null || customerList[i].Tickets.Count == 0)
                                        Background.DisplayMsg(" NO DEACTIVE TICKET ", size.Average, Y + 8);

                                    else if (customerList[i].Tickets.Count != 0)
                                    {
                                        for (int j = 0; j < customerList[i].Tickets.Count; j++)
                                        {
                                            if (customerList[i].Tickets[j].Begin < DateTime.Now)
                                                TicketDisplay(false);

                                            else
                                            {
                                                Background.DisplayMsg(" NO DEACTIVE TICKET ", size.Average, Y + 8);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        CustomCabinet();
                        break;
                }
            }
        }
        private void TicketDisplay(bool check)
        {

            string filePath = "customers.json";
            var jsonData = File.ReadAllText(filePath);
            var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                ?? new List<Customer>();


            Console.Clear();
            ConsoleKeyInfo cki;
            int cItem = 0;
            int cItem2 = 0;
            string code = "#";
            Random rand = new Random();

            List<string> codes = new List<string>();
            int lastWidth = Console.WindowWidth;
            int lastHeight = Console.WindowHeight;

            Console.SetWindowSize(90, 27);
            Point point = new Point(24, 7);
            ConsoleRectangle rectangle = new ConsoleRectangle(48, 10, point, ConsoleColor.DarkGray);
            rectangle.Draw();
            int z = 8;
            Console.OutputEncoding = Encoding.Unicode;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(67, z);
                if (i == 0 || i == 4 || i == 5 || i == 7)
                    Background.WriteLine("▄▄▄▄▄▄");
                else if (i == 1 || i == 2 || i == 3 || i == 8 || i == 6 || i == 9)
                    Background.WriteLine("▬▬▬▬▬▬");
                else
                    Background.WriteLine("      ");

                z++;
            }
            z = 8;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(66, z);
                Console.Write("║");
                z++;
            }
            Console.SetCursorPosition(25, 10);
            for (int k = 0; k < 41; k++)
            {
                Console.Write("═");
            }
            Console.SetCursorPosition(25, 12);

            for (int k = 0; k < 41; k++)
            {
                Console.Write("═");
            }
            Console.SetCursorPosition(46, 13);
            Console.Write("║");
            Console.SetCursorPosition(25, 14);

            for (int k = 0; k < 41; k++)
            {
                Console.Write("═");
            }
            Console.SetCursorPosition(46, 15);
            Console.Write("║");
            Console.SetCursorPosition(25, 16);

            for (int k = 0; k < 41; k++)
            {
                Console.Write("═");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(26, 13);
            Console.WriteLine("DATE");

            Console.SetCursorPosition(49, 13);
            Console.WriteLine("TIME");

            Console.SetCursorPosition(26, 15);
            Console.WriteLine("ROW");

            Console.SetCursorPosition(49, 15);
            Console.WriteLine("SEAT");
            Console.ResetColor();

            List<Ticket> movies = new List<Ticket>();

            for (int i = 0; i < customerList.Count; i++)
            {
                if (UserName == customerList[i].UserName)
                {
                    for (int e = 0; e < customerList[i].Tickets.Count; e++)
                    {
                        code = "#";
                        while (code.Length != 9)
                        {
                            int a = rand.Next(0, 9);
                            code += a;
                        }
                        codes.Add(code);
                    }

                    for (int j = 0; j < customerList[i].Tickets.Count; j++)
                    {
                        if (check == true)
                        {
                            if (customerList[i].Tickets[j].Begin > DateTime.Now)
                                movies.Add(customerList[i].Tickets[j]);
                        }
                        else
                        {
                            if (customerList[i].Tickets[j].Begin < DateTime.Now)
                                movies.Add(customerList[i].Tickets[j]);
                        }
                    }
                }
            }

            while (true)
            {

                Console.SetCursorPosition(47 - (movies[cItem].Place.Length / 2), 9);
                Console.Write(movies[cItem].Place);

                Console.SetCursorPosition(47 - (movies[cItem].Name.Length / 2), 11);
                Console.Write(movies[cItem].Name);

                Console.SetCursorPosition(31, 13);
                Console.WriteLine(movies[cItem].Begin.ToShortDateString());

                Console.SetCursorPosition(54, 13);
                Console.WriteLine(movies[cItem].Begin.ToShortTimeString());

                Console.SetCursorPosition(31, 15);
                Console.WriteLine(movies[cItem].Row);

                Console.SetCursorPosition(54, 15);
                Console.WriteLine(movies[cItem].Seat + "  ");


                Console.SetCursorPosition(25, 17);
                Console.WriteLine(codes[cItem]);

                switch (cItem2)
                {
                    case 0:
                        Console.SetCursorPosition(24, 19);
                        Background.WriteLine(" PREV ");
                        Console.SetCursorPosition(35, 19);
                        Console.Write(" NEXT ");
                        break;
                    case 1:
                        Console.SetCursorPosition(24, 19);
                        Console.WriteLine(" PREV ");
                        Console.SetCursorPosition(35, 19);
                        Background.WriteLine(" NEXT ");
                        break;
                }

                Console.CursorVisible = false;

                do
                {
                    cki = Console.ReadKey(true);
                } while (cki.Key != ConsoleKey.Escape && cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.Enter);

                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        cItem2--;
                        if (cItem2 < 0) cItem2 = 1;
                        break;
                    case ConsoleKey.RightArrow:
                        cItem2++;
                        if (cItem2 > 1) cItem2 = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (cItem2 == 0)
                        {
                            cItem--;
                            if (cItem < 0)
                                cItem = movies.Count - 1;
                        }
                        else if (cItem2 == 1)
                        {
                            cItem++;
                            if (cItem > movies.Count - 1)
                                cItem = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.SetWindowSize(lastWidth, lastHeight);
                        MyTicket();
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
            ConsoleRectangle rectangle = new ConsoleRectangle(size.aWidth, size.aHeight, point, ConsoleColor.DarkBlue);
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
                                CustomerMenu();
                            }
                            else
                            {
                                Background.DisplayMsg(" INVALID SIZE ", size.Average - 1, Y + 11);
                            }

                        }
                        break;
                    case ConsoleKey.Escape:
                        CustomerMenu();
                        break;
                }
            }
        }
    }
}
