using System;

namespace Customer
{
    public struct Ticket
    {
        private string name;
        private string place;
        private string row;
        private string seat;
        private string paymentMethod;
        private string price;
        private DateTime begin;


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
        public string Row
        {
            get { return row; }
            set { row = value; }
        }
        public string Seat
        {
            get { return seat; }
            set { seat = value; }
        }
        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }
    }
}
