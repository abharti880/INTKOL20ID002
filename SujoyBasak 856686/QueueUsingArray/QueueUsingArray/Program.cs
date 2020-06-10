using System;

namespace QueueUsingArray
{
    class Queue
    {
        int size = 10;
        int[] array = new int[100];        
        int front = -1, rear = -1;


        public bool push(int data)
        {
            if (rear == size - 1)
            {
                Console.WriteLine("Overflow");
                return false;
            }
            else if(front==-1 && rear==-1)
            {
                front = 0;
                rear = 0;
                array[rear] = data;
            }
            else
                array[++rear] = data;
            Console.WriteLine("Data Inserted");
            return true;
        }

        public bool pop()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("\nUnderflow\n");
                return false;

            }
            else if (front ==rear)
            {
                front = -1;
                rear = -1;
            }
            else
            {
                ++front;
                
            }
                

            return true;
        }
        public bool show()
        {
            if (rear == -1)
            {
                Console.WriteLine("Empty Queue");
                return false;
            }

                

            for(int i=front;i<=rear;i++)
            {
                Console.WriteLine(array[i]);
            }
            return true;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int flag = 0;
            Queue q = new Queue();
            do
            {
                Console.WriteLine("Enter 1 to Show");
                Console.WriteLine("Enter 2 to Push");
                Console.WriteLine("Enter 3 to Pop\n");
                Console.Write("Enter Choice");
                int key = int.Parse(Console.ReadLine());

                if (key == 1)
                    q.show();
                else if (key == 2)
                {
                    Console.Write("Enter Data: ");
                    int data = int.Parse(Console.ReadLine());
                    q.push(data);
                }
                else if (key == 3)
                    q.pop();

            }
            while (flag != 1);
            


        }
    }
}
