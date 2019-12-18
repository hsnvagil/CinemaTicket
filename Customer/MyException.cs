using System;

namespace Customer
{
    public class MyException : Exception
    {
        private string errMsg;
        public void SetError(string str)
        {
            errMsg += str;
        }
        public string GetError()
        {
            return errMsg;
        }
    }
}
