using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueue
{
    class Queue
    {
        int[] arr;
        int max, front, rear;
        public Queue(int size)
        {
            arr = new int[size];
            max = size;
            rear = -1;
            front = -1;
        }
        public void enqueue(int item)
        {
            if (rear == max - 1 && front==0)
            {
                Console.WriteLine("Queue is full");
            }
            else if(rear==-1 && front == -1){
                rear = 0;
                front = 0;
                arr[rear] = item;
                Console.WriteLine(item + " is enqueued to queue");
            }
            else
            {
                rear = (rear + 1) % max;
                arr[rear] = item;
                Console.WriteLine(item + " is enqueued to queue");
            }
        }
        public void dequeue()
        {
            int delitem = arr[front];
            if(rear==-1 && front == -1)
            {
                Console.WriteLine("Queue is empty");
            }
            else if(rear==front)
            {
                front = -1;
                rear = -1;
                Console.WriteLine("Deleted item is {0}",delitem);
            }
            else 
            {
                front = (front + 1) % max;
                Console.WriteLine("Deleted item is {0}", delitem);
            }
        }
        public void printqueue()
        {
            if (rear == -1 && front == -1)
            {
                Console.WriteLine("Queue is empty");
            }
            else
            {
                for(int i = front; i <= rear; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
}
