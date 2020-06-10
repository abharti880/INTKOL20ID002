using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingArray
{
    class MyQueue
    {
        int front,rear = -1; int[] queue = new int[100];
        void enqueue(int x)
        {
            if (rear == 99)
                Console.WriteLine("QUEUE OVERFLOW");
            else if (front == -1 || rear == -1)
            {
                front = rear = 0;
                queue[rear] = x;
            }
            else
             queue[++rear] = x; 
        }
        int deque()
        {
            int x = 0;
            if ( front== -1||front>rear)
                Console.WriteLine("QUEUE UNDERFLOW");
            else if(front==rear)
            {
                front=rear = -1;
            }
            else
            {
                x = queue[front];
                ++front;
            }
            return x;
        }
        void showstack()
        {
            
                Console.WriteLine("Current elements in the queue are:");
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine("{0} ",queue[i]);

                }
        }
        
        static void Main(string[] args)
        {
            MyQueue obj = new MyQueue();
            obj.deque();
            obj.enqueue(76);
            obj.enqueue(85);
            obj.enqueue(79);
            // Console.WriteLine(obj.pop());

            obj.enqueue(02);
            obj.enqueue(13);

            obj.showstack();
            Console.WriteLine("Dequed element is " + obj.deque());

            Console.WriteLine("Dequed element is " + obj.deque());
            obj.showstack();


            obj.enqueue(102);
            obj.enqueue(36);

            obj.showstack();
            Console.ReadKey();
        }
    }
}
