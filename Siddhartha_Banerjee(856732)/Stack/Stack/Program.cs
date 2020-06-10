using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class stack
    {
        private int[] ele;
        private int top;
        private int max;
        public stack(int size)
        {
            ele = new int[size];
            top = -1;
            max = size;
        }
        public void push(int item)
        {
            if(top==max-1)
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
            if(top==-1)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            else
            {
                Console.WriteLine("Popped Element is:" + ele[top]);
                return ele[top--];
            }
        }
        public void printStack()
        {
            if(top==-1)
            {
                Console.WriteLine("Stack Empty");
                return;
            }
            else
            {
                for(int i=0;i<=top;i++)
                {
                    Console.WriteLine("Item[" + (i + 1) + "]:" + ele[i]);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            stack s = new stack(5);
            s.push(10);
            s.push(20);
            s.push(30);
            s.push(40);
            s.push(50);

            Console.WriteLine("Items are:");
            s.printStack();

            s.pop();
            s.pop();
            s.pop();
            Console.ReadKey();
        }
    }
}
