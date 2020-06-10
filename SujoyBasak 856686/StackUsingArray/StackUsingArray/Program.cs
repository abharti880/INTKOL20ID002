using System;

namespace StackUsingArray
{
    


    class Stack
    {
        int[] array = new int[10];
        int size = 10;
        int top = -1;

        public bool push(int data)
        {
            if (top == size - 1)
            {
                Console.WriteLine("\nOverflow\n");
                return false;
            }

            array[++top] = data;
            Console.WriteLine("\nData Stacked\n");

            return true;
        }

        public bool pop()
        {
            if (top == -1)
            {
                Console.WriteLine("\nStack is Empty\n");
                return false;
            }
            --top;
            Console.WriteLine("\nData Poped\n");
            return true;
        }

        public void show()
        {
            if (top == -1)
                Console.WriteLine("\nStack is Empty\n");

            else
            {
                Console.WriteLine("\n Stack: ");

                for (int i = top; i >= 0; i--)
                    Console.WriteLine(" " + array[i]);

                Console.WriteLine("\n");
            }

        }

        public void peek()
        {
            if (top == -1)
                Console.WriteLine("\nStack is Empty\n");

            Console.WriteLine("\n" + array[top] + "\n");
        }

    }

    class Program   
    {
        static void Main(string[] args)
        {
            int flag = 0;
            Stack st = new Stack();
            do
            {
                Console.WriteLine("Enter 1 To Show");
                Console.WriteLine("Enter 2 to Push");
                Console.WriteLine("Enter 3 to Pop");
                Console.WriteLine("Enter 4 to Peek");
                Console.WriteLine("Enter 5 to Exit\n");

                Console.Write("Enter Choice: ");
                int key = int.Parse(Console.ReadLine());


                if (key == 1)
                    st.show();

                else if (key == 2)
                {
                    Console.Write("\nEnter Data: ");
                    int data = int.Parse(Console.ReadLine());
                    st.push(data);
                }
                else if (key == 3)
                    st.pop();
                else if (key == 4)
                    st.peek();
                else
                {
                    Console.WriteLine("\nClosing...");
                    flag = 1;
                }

            }
            while (flag != 1);




        }
    }
}
