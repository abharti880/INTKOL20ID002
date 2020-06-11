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
            if (((Rear + 1) % Size) == Front )
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
        public int? Peek()
        {
            if (Front == -1)
            {
                return null;
            }
            return Queue[Front];
        }
        public int Count()
        {
            if (Front == -1)
                return 0;
            else
            {
                int c = 0;
                for (int i = Front; i != Rear; i = ((i + 1) % Size))
                {
                    c++;
                }
                return ++c; //adding one rear element
            }
            
        }

        public void Clear()
        {
            Front = -1;
            Rear = -1;
            Console.WriteLine("------>  Cleared");
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
                for (int i = Front; i != Rear; i=((i + 1) % Size))
                {
                    Console.WriteLine(Queue[i]);
                }
                Console.WriteLine(Queue[Rear]); // displaying last Rear element
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
                Console.WriteLine("4. Peek");
                Console.WriteLine("5. Count");
                Console.WriteLine("6. Clear");
                Console.WriteLine("7. Exit");
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
                        if (queue.Peek() == null)
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        else
                        {
                            Console.WriteLine("Element at top = {0}", queue.Peek());

                        }
                        break;
                    case 5:
                        Console.WriteLine("Total Elements = {0}", queue.Count());
                        break;
                    case 6:
                        queue.Clear();
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
