using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueueArray
{
    class GenericQueue<T>
    {
        public int Front { get; set; }
        public int Rear { get; set; }
        public int Size { get; set; }
        public T[] Q { get; set; }
        public GenericQueue(int size)
        {
            Front = 0;
            Rear = -1;
            Size = size;
            Q = new T[Size];
        }
        public bool Enqueue(T val)
        {
            if (Rear == Size - 1)
                return false;
            Q[++Rear] = val;
            return true;
        }
        public T Dequeue()
        {
            if (Front > Rear || Front==-1)
            {
                Front = 0;
                Rear = -1;
                return default(T);
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
            GenericQueue<string> queue = new GenericQueue<string>(size);
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
                        string val = Console.ReadLine();
                        if (queue.Enqueue(val))
                            Console.WriteLine(val + " has been inserted into queue");
                        else
                            Console.WriteLine("Queue Overflow");
                        break;
                    case 2:
                        string topOfStack = queue.Dequeue();
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
