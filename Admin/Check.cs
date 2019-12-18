using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Admin
{
    public static class Check
    {
        public static bool CheckUsername(string username, int X, int Y)
        {
            MyException ex = new MyException();
            string filePath = "admins.json";
            var pattern = @"^(?=[A-Za-z0-9])(?!.*[._()\[\]-]{2})[A-Za-z0-9._()\[\]-]{5,15}$";

            try
            {
                if (username.Length == 0)
                {
                    ex.SetError(" USERNAME CAN'T BE BLANK ");
                    throw ex;
                }
                if (!Regex.IsMatch(username, pattern))
                {
                    ex.SetError(" PLEASE ENTER A VALID USERNAME ");
                    throw ex;
                }
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    var adminList = JsonConvert.DeserializeObject<List<Admin>>(jsonData)
                        ?? new List<Admin>();
                    for (int i = 0; i < adminList.Count; i++)
                    {
                        if (username == adminList[i].UserName)
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
        public static bool CheckEmail(string email, int X, int Y)
        {
            MyException ex = new MyException();
            var pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            string filePath = "admins.json";

            try
            {
                if (email.Length == 0)
                {
                    ex.SetError(" EMAIL ADDRESS CAN'T BE BLANK ");
                    throw ex;
                }
                if (!Regex.IsMatch(email, pattern))
                {
                    ex.SetError(" PLEASE ENTER A VALID EMAIL ADDRESS ");
                    throw ex;
                }
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    var adminList = JsonConvert.DeserializeObject<List<Admin>>(jsonData)
                        ?? new List<Admin>();
                    for (int i = 0; i < adminList.Count; i++)
                    {
                        if (email == adminList[i].Email)
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
                if (!Regex.IsMatch(Password, pattern))
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
        public static bool CheckPhone(string Phone, int X, int Y)
        {
            MyException ex = new MyException();
            var special = new string(Phone.Where(c => Char.IsDigit(c)
                   || Phone.Contains("+")).ToArray());
            string filePath = "admins.json";

            try
            {
                if (Phone.Length == 0)
                {
                    ex.SetError(" NUMBER CAN'T BE BLANK ");
                    throw ex;
                }
                if (Phone.Length < 7)
                {
                    ex.SetError(" INVALID NUMBER ");
                    throw ex;
                }
                if (special != Phone)
                {
                    ex.SetError(" INVALID NUMBER ");
                    throw ex;
                }
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    var adminList = JsonConvert.DeserializeObject<List<Admin>>(jsonData)
                        ?? new List<Admin>();
                    for (int i = 0; i < adminList.Count; i++)
                    {
                        if (Phone == adminList[i].Phone)
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
    }
}
