﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stackqueue
{
    class Stack
    {
        private int[] ele;
        private int top;
        private int max;
        public Stack(int size)
        {
            ele = new int[size];
            top = -1;
            max = size;
        }
        public void push(int item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                ele[++top] = item;

            }
        }
        public int pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            else
            {
                Console.WriteLine("Popped element is:" + ele[top]);
                return ele[top--];
            }
        }
        public void printStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }
            else
            {
                for (int i = 0; i <= top; i++)
                {
                    Console.WriteLine("Item[" + (i + 1) + "]: " + ele[i]);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack S = new Stack(5);
            S.push(10);
            S.push(20);
            S.push(30);
            S.push(40);
            S.push(50);

            Console.WriteLine("Items are :");
            S.printStack();

            S.pop();
            S.pop();
            S.pop();
            Console.ReadKey();
        }
    }
}