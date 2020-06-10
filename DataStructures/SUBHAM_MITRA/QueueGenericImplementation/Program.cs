using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueGenericImplementation
{
    class MyQueue<T>
    {
        int front, rear = -1; T[] queue = new T[100];
       public void enqueue(T x)
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
        public T deque()
        {
            T x = default(T);
            if (front == -1 || front > rear)
                Console.WriteLine("QUEUE UNDERFLOW");
            else if (front == rear)
            {
                front = rear = -1;
            }
            else
            {
                x = queue[front];
                ++front;
            }
            return x;
        }
        public void showstack()
        {

            Console.WriteLine("Current elements in the queue are:");
            for (int i = front; i <= rear; i++)
            {
                Console.WriteLine("{0} ", queue[i]);

            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<char> obj = new MyQueue<char>();
            obj.deque();
            obj.enqueue('a');
            obj.enqueue('b');
            obj.enqueue('c');
            

            obj.enqueue('d');
            obj.enqueue('e');

            obj.showstack();
            Console.WriteLine("Dequed element is " + obj.deque());

            Console.WriteLine("Dequed element is " + obj.deque());
            obj.showstack();


            obj.enqueue('f');
            obj.enqueue('g');

            obj.showstack();
            Console.ReadKey();


            MyQueue<double> obj1 = new MyQueue<double>();
            obj1.deque();
            obj1.enqueue(1.1);
            obj1.enqueue(1.2);
            obj1.enqueue(1.3);


            obj1.enqueue(1.4);
            obj1.enqueue(1.5);

            obj1.showstack();
            Console.WriteLine("Dequed element is " + obj1.deque());

            Console.WriteLine("Dequed element is " + obj1.deque());
            obj1.showstack();


            obj1.enqueue(1.6);
            obj1.enqueue(1.7);

            obj1.showstack();
            Console.ReadKey();



        }
    }
}
