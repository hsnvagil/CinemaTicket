using System;

namespace Customer
{
    public class WindowSize
    {
        public int width;
        public int height;
        public int beginWidth;
        public int beginHeight;
        public int aWidth;
        public int aHeight;
        public int average;

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }
        public int Height
        {
            get { return height; }
            private set { height = value; }
        }
        public int BWidth
        {
            get { return beginWidth; }
            private set { beginWidth = value; }
        }
        public int BHeight
        {
            get { return beginHeight; }
            private set { beginHeight = value; }
        }
        public int AWidth
        {
            get { return aWidth; }
            private set { aWidth = value; }
        }
        public int AHeight
        {
            get { return aHeight; }
            private set { aHeight = value; }
        }
        public int Average
        {
            get { return average; }
            private set { average = value; }
        }

        public WindowSize()
        {
            Width = Console.WindowWidth - 1;
            Height = Console.WindowHeight - 1;
            beginWidth = 2;
            beginHeight = 1;
            aWidth = Width - (beginWidth * 2) - 1;
            aHeight = Height - (beginHeight * 2) - 1;
            Average = Width / 2;
        }
    }
}
