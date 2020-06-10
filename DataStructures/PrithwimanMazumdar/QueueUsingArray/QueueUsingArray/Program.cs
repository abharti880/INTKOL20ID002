using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingArray
{
    class MyQueue
    {
        public int Front { get; set; }
        public int Rear { get; set; }
        public int Size { get; set; }
        public int[] Q { get; set; }
        public MyQueue(int size)
        {
            Front = Rear = -1;
            Size = size;
            Q = new int[Size];
        }
        public bool Enqueue(int val)
        {
            if (Rear == Size - 1)
                return false;
            Q[++Rear] = val;
            if (Front == -1)
                Front++;
            return true;
        }
        public int? Dequeue()
        {
            if (Front > Rear)
            {
                Front = Rear = -1;
                return null;
            }
            return Q[Front++];
        }
        public void Print()
        {
            Console.WriteLine("Queue:");
            for (int i = Front; i <= Rear; i++)
                Console.WriteLine(Q[i]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter size of Queue:");
            int size = int.Parse(Console.ReadLine());
            MyQueue queue = new MyQueue(size);
            bool exit = false;
            int ch;
            while (!exit)
            {
                Console.WriteLine("1. Enqueue");
                Console.WriteLine("2. Dequeue");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter Choice:");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter value:");
                        int val = int.Parse(Console.ReadLine());
                        if (queue.Enqueue(val))
                            Console.WriteLine(val + " has been inserted into queue");
                        else
                            Console.WriteLine("Queue Overflow");
                        break;
                    case 2:
                        int? topOfStack = queue.Dequeue();
                        if (topOfStack == null)
                            Console.WriteLine("Queue Underflow");
                        else
                            Console.WriteLine(topOfStack + " has been deleted from queue");
                        break;
                    case 3:
                        queue.Print();
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