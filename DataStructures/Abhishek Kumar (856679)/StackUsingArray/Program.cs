using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingArray
{
    class MyStack
    {
        public int Top { get; set; }
        public int Size { get; set; }
        public int[] Stack { get; set; }
        public MyStack(int size)
        {
            Top = -1;
            Size = size;
            Stack = new int[Size];
        }
        public bool Push(int val)
        {
            if (Top == Size - 1)
                return false;
            Stack[++Top] = val;
            return true;
        }
        public int? Pop()
        {
            if (Top == -1)
                return null;
            return Stack[Top--];
        }
        public void peek()
        {
            if (Top == -1)
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                Console.WriteLine("Top element is {0}", Stack[Top]);
            }
        }
        public int Count()
        {
            return Top;
        }

        
        public void Clear()
        {
            Top = -1;
            Console.WriteLine("Stack cleared");
        }

        public void Print()
        {
            Console.WriteLine("Stack:");
            if (Top == -1)
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                for (int i = Top; i > -1; i--)
                    Console.WriteLine(Stack[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of Stack:");
            int size = int.Parse(Console.ReadLine());
            MyStack stack = new MyStack(size);
            bool exit = false;
            int ch;
            while (!exit)
            {
                Console.WriteLine("\n****************");
                Console.WriteLine("1. Push");
                Console.WriteLine("2. Pop");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Peek");
                Console.WriteLine("5. Count");
                Console.WriteLine("6. Clear ");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter Choice:");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter value:");
                        int val = int.Parse(Console.ReadLine());
                        if (stack.Push(val))
                            Console.WriteLine(val + " has been pushed onto stack");
                        else
                            Console.WriteLine("Stack Overflow");
                        break;
                    case 2:
                        int? topOfStack = stack.Pop();
                        if (topOfStack == null)
                            Console.WriteLine("Stack Underflow");
                        else
                            Console.WriteLine(topOfStack + " has been popped out of stack");
                        break;
                    case 3:
                        stack.Print();
                        break;
                    case 4:
                        stack.peek();
                        break;
                    case 5:
                        if(stack.Top == -1)
                        {
                            Console.WriteLine("Empty");
                        }
                        else
                        {
                            Console.WriteLine("Count = {0}",stack.Top+1);
                        }

                        break;
                    case 6:
                        stack.Clear();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
