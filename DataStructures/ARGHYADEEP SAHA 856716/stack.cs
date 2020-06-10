using System;
public class stack

{
    private int maxSize;
    private long[] stackArray;
    private int top;

    public stack(int s)
    {
        maxSize = s;
        stackArray = new long[maxSize];
        top = -1;
    }
    public void push(long j)
    {
        stackArray[++top] = j;
    }
    public long pop()
    {
        return stackArray[top--];
    }
    public long peek()
    {
        return stackArray[top];
    }
    public bool isEmpty()
    {
        return (top == -1);
    }
    public bool isFull()
    {
        return (top == maxSize - 1);
    }
    public static void Main()
    {
        stack theStack = new stack(10);
        theStack.push(10);
        theStack.push(20);
        theStack.push(30);
        theStack.push(40);
        theStack.push(50);

        while (!theStack.isEmpty())
        {
            long value = theStack.pop();
            Console.WriteLine(value);
            Console.WriteLine(" ");
        }
        Console.WriteLine("");
    }
}