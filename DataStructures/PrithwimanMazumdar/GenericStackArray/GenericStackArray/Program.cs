﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStackArray
{
    class GenericStack<T>
    {
        public int Top { get; set; }
        public int Size { get; set; }
        public T[] Stk { get; set; }
        public GenericStack(int size)
        {
            Top = -1;
            Size = size;
            Stk = new T[Size];
        }
        public bool Push(T val)
        {
            if (Top == Size - 1)
                return false;
            Stk[++Top] = val;
            return true;
        }
        public T Pop()
        {
            if(Top == -1)
                return default(T);
            return Stk[Top--];
        }
        public void Print()
        {
            Console.WriteLine("Stack:");
            for (int i = 0; i <= Top; i++)
                Console.WriteLine(Stk[i]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of Stack:");
            int size = int.Parse(Console.ReadLine());
            GenericStack<string> stack = new GenericStack<string>(size);
            bool exit = false;
            int ch;
            while (!exit)
            {
                Console.WriteLine("1. Push");
                Console.WriteLine("2. Pop");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter Choice:");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter value:");
                        string val = Console.ReadLine();
                        if (stack.Push(val))
                            Console.WriteLine(val + " has been pushed onto stack");
                        else
                            Console.WriteLine("Stack Overflow");
                        break;
                    case 2:
                        string topOfStack = stack.Pop();
                        if (topOfStack == null)
                            Console.WriteLine("Stack Underflow");
                        else
                            Console.WriteLine(topOfStack + " has been popped out of stack");
                        break;
                    case 3:
                        stack.Print();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
