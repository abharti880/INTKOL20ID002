using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackusingArray
{
    internal class Stack
    {
        static readonly int max = 1000;
        int top;
        int[] stk = new int[max];

        bool IsEmpty()
        {
            return (top < 0);
        }
        public Stack()
        {
            top = -1;
        }
        internal bool Push(int data)
        {
            if(top>=max)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                stk[++top] = data;
                return true;
            }
        }
        internal int Pop()
        {
            if(top<0)
            {
                Console.WriteLine("Stack Underflow");
                return 0;
            }
            else
            {
                int value = stk[top--];
                return value;
            }
        }
        internal void Peek()
        {
            if(top<0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
            {
                Console.WriteLine("The topmost element of stack is :{0}", stk[top]);
            }
        }
        internal void PrintStack()
        {
            
            if(top<0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
            {
                Console.WriteLine("Items in the stack are:");
                for ( int i = top; i >= 0; i--)
                {
                    Console.WriteLine(stk[i]);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();
            myStack.Push(10);
            myStack.Push(30);
            myStack.Push(50);
            myStack.Push(70);
            myStack.PrintStack();
            myStack.Peek();
            Console.WriteLine("Item popped from stack: {0}", myStack.Pop());
            myStack.PrintStack();
            Console.ReadLine();

        }
    }
}
