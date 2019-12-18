using System;
using System.Collections.Generic;

namespace Admin
{
    public struct Movie
    {
        private string name;
        private string place;
        private string language;
        private string type;
        private DateTime begin;
        private int duration;
        private double price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public List<int> BusySeats { get; set; }
    }
}
