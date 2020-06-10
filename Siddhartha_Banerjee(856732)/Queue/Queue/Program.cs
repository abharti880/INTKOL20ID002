using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class LinearQueue
    {
        private int[] ele;
        private int front;
        private int rear;
        private int max;
        public LinearQueue(int size)
        {
            ele = new int[size];
            front = 0;
            rear = -1;
            max = size;
        }
        public void insert(int item)
        {
            if(rear == max-1)
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            else 
            {
                ele[++rear] = item;
            }
        }
        public int delete()
        {
            if(front == rear + 1)
            {
                Console.WriteLine("Queue is empty");
                return -1;
            }
            else
            {
                Console.WriteLine("Deleted element is:" + ele[front]);
                return ele[front++];
            }
        }
        public void printQueue()
        {
            if (front == rear + 1)
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                for(int i=front;i<=rear;i++)
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
            LinearQueue q = new LinearQueue(5);
            q.insert(10);
            q.insert(20);
            q.insert(30);
            q.insert(40);
            q.insert(50);

            Console.WriteLine("Items are:");
            q.printQueue();

            q.delete();
            q.delete();

            Console.WriteLine("Items are:");
            q.printQueue();
            Console.ReadKey();
        }
    }
}
