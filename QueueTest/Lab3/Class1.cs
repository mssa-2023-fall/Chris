using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

public class CarStackWithLinkedList<T>
{
    private LinkedList<T> carList = new LinkedList<T>();

    public void Push(T car)
    {
        carList.AddFirst(car);
    }

    public void Pop()
    {
        if (carList.Count == 0)
            throw new Exception("Empty car list");
        else
        {
            T car = carList.Last.Value;
            carList.RemoveLast();
            return;
        }
    }

    public void Clear()
    {
        carList.Clear();
    }

    public T Peek()
    {
        if (carList.Count == 0)
            throw new Exception("Empty car list");
        else
        {
            return carList.Last.Value;
        }
    }

    public int Count
    { get { return carList.Count; } }
}

