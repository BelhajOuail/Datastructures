using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public  class StackInt
    {
        private int[] stackArray;
        private int top = 0;

        public StackInt(int InitialSize)
        {
            stackArray = new int[InitialSize];
        }

        public void Push(int getal)
        {
            lock (this)
            {

                if (IsFull)
                {
                    var newArray = new int[stackArray.Length * 2];
                    for (int f = 0; f < stackArray.Length; f++)
                        newArray[f] = stackArray[f];
                    stackArray = newArray;
                }

                stackArray[top++] = getal;
            }
        }

        public int Pop()
        {
            lock (this)
            {

                if (IsEmpty)
                    throw new Exception("The stack is empty. Pop is not allowed");

                return stackArray[--top];
            }
        }

        public int Peek()
        {
            lock (this)
            {

                if (IsEmpty)
                    throw new Exception("The stack is empty. Peek is not allowed");

                return stackArray[top - 1];
            }
        }

        public bool IsEmpty
        {
            get
            {
                lock (this)
                {
                    return top == 0;
                }
            }
        }

        public bool IsFull
        {
            get
            {
                lock (this)
                {
                    return top == stackArray.Length;
                }
            }
        }

        public int[] Items
        {
            get
            {
                lock (this)
                {
                    int[] temp = new int[top];
                    if (top != 0)
                        Array.Copy(stackArray, temp, top);
                    return temp;
                }
            }
        }
    }
}
