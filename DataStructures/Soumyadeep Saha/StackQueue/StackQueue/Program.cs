using System;

namespace StackQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack st = new Stack(5);
            Console.WriteLine("-----------Stack operation---------");
            st.push(3);
            st.push(10);
            st.push(7);
            st.printstack();
            Console.WriteLine("After popping out element");
            st.pop();
            st.printstack();
            Console.WriteLine("Peek Operation");
            st.peek();

            Console.WriteLine("------------- Queue operation---------------");
            Queue qu = new Queue(5);
            qu.enqueue(25);
            qu.enqueue(30);
            qu.enqueue(15);
            qu.enqueue(50);
            qu.printqueue();
            Console.WriteLine("------------------Dequeue operation----------------");
            qu.dequeue();
            qu.dequeue();
            qu.printqueue();
        }
    }
}
