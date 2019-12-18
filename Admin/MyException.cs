namespace Admin
{
    public class MyException : System.Exception
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
