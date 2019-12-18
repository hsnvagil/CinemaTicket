using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Customer
{
    public class Card
    {
        private string fullName;
        private string cardType;
        private string cardNo;
        private string cvv;
        private DateTime expDate;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }
        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }
        public string CVV
        {
            get { return cvv; }
            set { cvv = value; }
        }
        public DateTime ExpDate
        {
            get { return expDate; }
            set { expDate = value; }
        }

        public static string CardNumberGenerator()
        {
            string number = "";
            Random rand = new Random();
            while (number.Length != 19)
            {
                int a = rand.Next(0, 9);
                number += a;
                if (number.Length == 4 || number.Length == 9 || number.Length == 14)
                    number += " ";
            }
            string filePath = "customers.json";
            var jsonData = File.ReadAllText(filePath);
            var customerList = JsonConvert.DeserializeObject<List<Customer>>(jsonData)
                ?? new List<Customer>();
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].UCard != null)
                {
                    for (int j = 0; j < customerList[i].UCard.Count; j++)
                    {
                        if (number == customerList[i].UCard[j].CardNo)
                        {
                            CardNumberGenerator();
                            break;
                        }
                    }
                }
            }

            return number;
        }
        public static string CardCVVGenerator()
        {
            string number = "";
            Random rand = new Random();
            while (number.Length != 3)
            {
                int a = rand.Next(0, 9);
                number += a;
            }
            return number;
        }
        public static string CardPinGenerator()
        {
            string number = "";
            Random rand = new Random();
            while (number.Length != 4)
            {
                int a = rand.Next(1, 9);
                number += a;
            }
            return number;
        }
    }
}
