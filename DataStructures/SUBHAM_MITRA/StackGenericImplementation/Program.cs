using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericImplementation
{
    class Mystack<T>
    {

        int top = -1; T[] stack = new T[100];
        public void push(T x)
        {
            if (top == 99)
                Console.WriteLine("STACK OVERFLOW");
            else
                stack[++top] = x;
        }
        public T pop()
        {
           
             if (top == -1)
             {  
                Console.WriteLine("STACK UNDERFLOW");
                return default(T); 
             }
            else
            {
            return stack[top--];
            }
        }
       public void showstack()
        {
            if (top == -1)
                Console.WriteLine("STACK UNDERFLOW");
            else
            {
                Console.WriteLine("Current elements in the stack are:");
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(stack[i]);

                }
            }
        }
    }
     class Program
    {
         static void Main(string[] args)
        {
            Mystack<string> obj = new Mystack<string>();

            obj.pop();
            obj.push("Subham");
            obj.push("Virat");
            obj.push("Messi");
           

            obj.push("Ronaldo");
            obj.push("Sunil");

            obj.showstack();
            Console.WriteLine("Popped element is " + obj.pop());

            Console.WriteLine("Popped element is " + obj.pop());
            obj.showstack();


            obj.push("Smriti");
            obj.push("Mahi");

            obj.showstack();
            Console.ReadKey();

            Mystack<int> obj1 = new Mystack<int>();

            obj1.pop();
            obj1.push(10);
            obj1.push(20);
            obj1.push(30);


            obj1.push(40);
            obj1.push(50);

            obj1.showstack();
            Console.WriteLine("Popped element is " + obj1.pop());

            Console.WriteLine("Popped element is " + obj1.pop());
            obj1.showstack();


            obj1.push(60);
            obj1.push(70);

            obj1.showstack();
            Console.ReadKey();

        }
    }
}

