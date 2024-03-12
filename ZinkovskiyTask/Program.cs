using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedArray<T>
{
    protected Node<T> head;

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void Print()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Bag<T> : LinkedArray<T>
{
    // Мішок (Bag) - просто зберігає елементи без упорядкування
    public void AddToBag(T data)
    {
        Add(data);
    }
}

public class Queue<T> : LinkedArray<T>
{
    // Черга (Queue) - додає елементи в кінець і видаляє їх з початку
    public void Enqueue(T data)
    {
        Add(data);
    }

    public T Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T data = head.Data;
        head = head.Next;
        return data;
    }
}

public class Stack<T> : LinkedArray<T>
{
    // Стек (Stack) - додає і видаляє елементи з одного кінця (верхушки)
    public void Push(T data)
    {
        Node<T> newNode = new Node<T>(data);
        newNode.Next = head;
        head = newNode;
    }

    public T Pop()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T data = head.Data;
        head = head.Next;
        return data;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bag<int> bag = new Bag<int>();
        bag.AddToBag(1);
        bag.AddToBag(2);
        bag.AddToBag(3);
        bag.Print();

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("first");
        queue.Enqueue("second");
        queue.Enqueue("third");
        Console.WriteLine(queue.Dequeue());

        Stack<double> stack = new Stack<double>();
        stack.Push(3.14);
        stack.Push(2.71);
        Console.WriteLine(stack.Pop());
    }
}
