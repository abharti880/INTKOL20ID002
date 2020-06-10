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
        public int[] Queue { get; set; }
        public MyQueue(int size)
        {
            Front = Rear = -1;
            Size = size;
            Queue = new int[Size];
        }
        public bool Enqueue(int val)
        {
            if (Rear == Size - 1 && Front == 0)
                return false;
            Rear = (Rear + 1) % Size;
            Queue[Rear] = val;
            if (Front == -1)
                Front++;
            return true;
        }
        public int? Dequeue()
        {
            if (Front == -1 && Rear == -1)
            {
                return null;
            }
            else if (Rear == Front)
            {
                int tem = Front;
                Front = -1;
                Rear = -1;
                return Queue[tem];
            }
            else
            {
                int tem = Front;
                Front = (Front + 1) % Size;
                return Queue[tem];
            }
        }
        public void Print()
        {
            Console.WriteLine("Queue:");
            if (Front == -1 && Rear == -1)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (int i = Front; i <= Rear; i++)
                    Console.WriteLine(Queue[i]);
            }
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
                Console.WriteLine("\n******************************");
                Console.WriteLine("1. Enqueue");
                Console.WriteLine("2. Dequeue");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter Choice:");
                Console.WriteLine();

                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter value:");
                        int val = int.Parse(Console.ReadLine());
                        if (queue.Enqueue(val))
                            Console.WriteLine(val + " has been inserted into queue");
                        else
                            Console.WriteLine("could not insert, Queue is full.");
                        break;
                    case 2:
                        int? top = queue.Dequeue();
                        if (top == null)
                            Console.WriteLine("could not Dequeue, Queue is empty");
                        else
                            Console.WriteLine(top + " has been deleted from queue");
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