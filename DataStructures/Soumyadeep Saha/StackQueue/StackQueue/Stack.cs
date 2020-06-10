using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueue
{
    class Stack
    {
        int[] arr;
         int max, top;
        public Stack(int size)
        {
            arr = new int[size];
            max = size;
            top = -1;
        }
        public void push(int item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow");
            }
            else
            {
                arr[++top] = item;
                Console.WriteLine(item+ " is pushed to stack");
            }
        }
        public void pop()
        {
            int delitem = arr[top];
            if (top == -1) {
                Console.WriteLine("Stack is empty");  
            }
            else
            {
                top = top - 1;
                Console.WriteLine("Deleted item is {0}", delitem);
            }
        }
        public void peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
            }
            else {
                int topitem = arr[top];
                Console.WriteLine("Top element is {0}",topitem);
            }
        }
        public void printstack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                for(int i = 0; i <= top; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
}
