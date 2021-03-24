﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class StackInt
    {
        private int[] stackArray;
        private int top = 0;

        public StackInt(int InitialSize = 5)
        {
            stackArray = new int[InitialSize];
        }

        public void Push(int getal)
        {
            if (IsFull)
            {
                var newArray = new int[stackArray.Length * 2];
                Array.Copy(stackArray, newArray, stackArray.Length);
                //for (int f = 0; f < stackArray.Length; f++)   //alternatief
                //    newArray[f] = stackArray[f];
                stackArray = newArray;
            }

            stackArray[top++] = getal;
        }

        public int Pop()
        {

            if (IsEmpty)
                throw new Exception("The stack is empty. Pop is not allowed");

            return stackArray[--top];
        }

        public int Peek()
        {
            if (IsEmpty)
                throw new Exception("The stack is empty. Peek is not allowed");

            return stackArray[top - 1];
        }

        public bool IsEmpty
        {
            get
            {
                return top == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return top == stackArray.Length;
            }
        }

        public int[] Items
        {
            get
            {
                int[] temp = new int[top];
                if (top != 0)
                    Array.Copy(stackArray, temp, top);
                return temp;
            }
        }
    }
}
