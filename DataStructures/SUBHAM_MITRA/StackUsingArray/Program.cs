using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingArray
{
    class Mystack
    {
        int top = -1;int[] stack=new int[100]; 
        void push(int x)
        {
            if (top == 99)
                Console.WriteLine("STACK OVERFLOW");
            else
                stack[++top] = x;
        }
        int pop()
        {
            int x=0;
            if (top==-1)
                Console.WriteLine("STACK UNDERFLOW");
            else
            {
                x = stack[top];
                top--;
            }
            return x;
        }
        void showstack()
        {
            if(top==-1)
                Console.WriteLine("STACK UNDERFLOW");
            else
            {
                Console.WriteLine("Current elements in the stack are:");
                for (int i=top;i>=0;i--)
                {
                    Console.WriteLine(stack[i]);
                    
                }
            }
        }
        static void Main(string[] args)
        {
            Mystack obj = new Mystack();
            obj.pop();
            obj.push(76);
            obj.push(85);
            obj.push(79);
            // Console.WriteLine(obj.pop());

            obj.push(02);
            obj.push(13);

            obj.showstack();
            Console.WriteLine("Popped element is " + obj.pop());

            Console.WriteLine("Popped element is " + obj.pop());
            obj.showstack();


            obj.push(102);
            obj.push(36);

            obj.showstack();
            Console.ReadKey();
        }
    }
}
