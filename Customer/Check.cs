using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Customer
{
    public static class Check
    {
        public static bool CheckUsername(string username, int X, int Y, string cUsername = "")
        {
            MyException ex = new MyException();
            string filePath = "customers.json";
            var pattern = @"^(?=[A-Za-z0-9])(?!.*[._()\[\]-]{2})[A-Za-z0-9._()\[\]-]{5,15}$";

            try
            {
                if (username.Length == 0)
                {
                    ex.SetError(" USERNAME CAN NOT BE BLANK ");
                    throw ex;
                }
                else if (!Regex.IsMatch(username, pattern))
                {
                    ex.SetError(" PLEASE ENTER A VALID USERNAME ");
                    throw ex;
                }
                else if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    var adminList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                        ?? new List<Customer>();
                    for (int i = 0; i < adminList.Count; i++)
                    {
                        if (username == adminList[i].UserName && username != cUsername)
                        {
                            ex.SetError(" USERNAME IS ALREADY TAKEN ");
                            throw ex;
                        }
                    }
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
        public static bool CheckEmail(string email, int X, int Y, string cEmail = "")
        {
            MyException ex = new MyException();
            var pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            string filePath = "customers.json";

            try
            {
                if (email.Length == 0)
                {
                    ex.SetError(" EMAIL ADDRESS CANNOT BE BLANK ");
                    throw ex;
                }
                else if (!Regex.IsMatch(email, pattern))
                {
                    ex.SetError(" PLEASE ENTER A VALID EMAIL ADDRESS ");
                    throw ex;
                }
                else if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    var adminList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                        ?? new List<Customer>();
                    for (int i = 0; i < adminList.Count; i++)
                    {
                        if (email == adminList[i].Email && email != cEmail)
                        {
                            ex.SetError(" EMAIL ADDRESS IS ALREADY TAKEN ");
                            throw ex;
                        }
                    }
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
        public static bool CheckPhone(string Phone, int X, int Y, string cPhone = "")
        {
            MyException ex = new MyException();
            var special = new string(Phone.Where(c => Char.IsDigit(c)).ToArray());
            string filePath = "customers.json";

            try
            {
                if (Phone.Length == 0)
                {
                    ex.SetError(" NUMBER CANNOT BE BLANK ");
                    throw ex;
                }
                else if (special != Phone)
                {
                    ex.SetError(" INVALID NUMBER ");
                    throw ex;
                }
                else if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    var adminList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                        ?? new List<Customer>();
                    for (int i = 0; i < adminList.Count; i++)
                    {
                        if (Phone == adminList[i].Phone && Phone != cPhone)
                        {
                            ex.SetError(" PHONE IS ALREADY TAKEN ");
                            throw ex;
                        }
                    }
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
        public static bool CheckPassword(string Password, int X, int Y)
        {
            MyException ex = new MyException();
            var pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";

            try
            {
                if (Password.Length == 0)
                {
                    ex.SetError(" PASSWORD CAN'T BE BLANK ");
                    throw ex;
                }
                else if (!Regex.IsMatch(Password, pattern))
                {
                    ex.SetError(" PLEASE ENTER A VALID PASSWORD ");
                    throw ex;
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
        public static bool CheckName(string name, int X, int Y)
        {
            MyException ex = new MyException();
            var pattern = @"^[a-zA-Z][a-zA-Z\\s]+$";

            try
            {
                if (name.Length == 0)
                {
                    ex.SetError(" NAME CANNOT BE BLANK ");
                    throw ex;
                }
                else if (!Regex.IsMatch(name, pattern))
                {
                    ex.SetError(" INVALID NAME ");
                    throw ex;
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
        public static bool CheckSurname(string surname, int X, int Y)
        {
            MyException ex = new MyException();
            var pattern = @"^[a-zA-Z][a-zA-Z\\s]+$";

            try
            {
                if (surname.Length == 0)
                {
                    ex.SetError(" SURNAME CAN'T BE BLANK ");
                    throw ex;
                }
                else if (!Regex.IsMatch(surname, pattern))
                {
                    ex.SetError(" INVALID SURNAME ");
                    throw ex;
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
        public static bool CheckBirthday(DateTime date, int X, int Y)
        {
            MyException ex = new MyException();
            try
            {
                if (date > new DateTime(2010, 12, 31))
                {
                    ex.SetError(" INVALID BIRTHDAY ");
                    throw ex;
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
        public static bool CheckIdenty(string identy, int X, int Y)
        {
            MyException ex = new MyException();
            var pattern = new string(identy.Where(c => Char.IsDigit(c)).ToArray());

            try
            {
                if (pattern != identy)
                {
                    ex.SetError(" ONLY NUMBER ");
                    throw ex;
                }
                else if (identy.Length != 8)
                {
                    ex.SetError(" PLEASE ENTER A VALID IDENTY NUMBER ");
                    throw ex;
                }
            }
            catch (MyException ex1)
            {
                Background.DisplayMsg(ex1.GetError(), X, Y);
                return false;
            }
            return true;
        }
    }
}
