using System;
class queueprogram
{
int[] queue;
int n;
int front;
int rear;
public queueprogram()
{
    queue=new int[100];
    n=100;
    front=-1;
    rear=-1;
}
void Insert() {
   int val;
   if (rear == n - 1)
      Console.WriteLine("Queue overflow");
   else {
      if (front == - 1)
      front = 0;
      Console.WriteLine("Insert the element in queue");
      val=Convert.ToInt32(Console.ReadLine());
      rear++;
      queue[rear] = val;
   }
}
void Delete() {
   if (front == - 1 || front > rear) {
      Console.WriteLine("Queue underflow");
   return ;
   } 
   else {
       Console.WriteLine("Element deleted from queue is {0} :",queue[front]);
      front++;;
   }
}
void Display() {
   if (front == - 1)
   Console.WriteLine("Queue is empty");
   else {
      Console.WriteLine("Queue elements are :");
      for (int i = front; i <= rear; i++)
         Console.WriteLine(queue[i]);
   }
}
static void Main() {
    queueprogram ob=new queueprogram();
   int ch;
   Console.WriteLine("Insert element to queue");
   Console.WriteLine("Delete element from queue");
   Console.WriteLine("Display all the elements of queue");
   Console.WriteLine("Exit");
do 
{
   Console.WriteLine("Enter your choice : ");
   ch=Convert.ToInt32(Console.ReadLine());
   switch (ch) {
      case 1: ob.Insert();
         break;
      case 2: ob.Delete();
         break;
      case 3: ob.Display();
         break;
      case 4: Console.WriteLine("Exit");
         break;
      default: Console.WriteLine("Invalid choice");
      break;
   }
} 
while(ch!=4);
}
}