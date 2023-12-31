﻿using EventExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading.Channels;
using System.IO;


NoisyListSample();

void NoisyListSample()
{
    NoisyList<string> list = new NoisyList<string>(new string[] { "Apple", "Banana", "Cherry" }) { Name = "StringList" };
    NoisyList<int> list2 = new NoisyList<int>(new int[] { 1, 2, 3 }) { Name = "IntList" };
    list.OnItemAdded +=
        (l, arg) => Console.WriteLine($"{l.Name} added a new item: {arg.ItemAdded} in position {arg.ItemPositionInList} on {arg.InsertionTimestamp}");
    list2.OnItemRemoved += List2_OnItemRemoved<int>;

    list.Add("Durian");
    list2.Add(123);
    Console.WriteLine("items added");
    list.Remove("Apple");
    list2.Remove(1);
    Console.WriteLine("Items Removed");
    Console.WriteLine("Press 'enter' to end the program.");
    Console.ReadLine();

}

void List2_OnItemRemoved<T>(NoisyList<T> arg1, (int CountBeforeRemove, int CountAfterRemove, int ItemRemoved, DateTime RemoveTimestamp) arg2)
{
    Console.WriteLine($"{arg2.ItemRemoved} was removed from {arg1.Name} on {arg2.RemoveTimestamp}, there are {arg2.CountAfterRemove} items now.");
}
namespace EventExercise
{
    public class NoisyList<T>
    {
        private List<T> list;
        public NoisyList()
        {
            list = new List<T>();
        }
        public NoisyList(T[] _array)
        {
            list = new List<T>(_array);
        }
        public void Add(T item)
        {

            list.Add(item);
            if (OnItemAdded != null) // only prepare arg if someone is listening
            {
                var arg = new OnItemAddedEventArgs<T>
                {
                    CountBeforeAddition = list.Count - 1,
                    CountAfterAddition = list.Count,
                    ItemAdded = item,
                    InsertionTimestamp = DateTime.Now,
                    ItemPositionInList = list.IndexOf(item)
                };
                OnItemAdded.Invoke(this, arg); //raising the event
            }
        }
        public string Name { get; set; }
        public void Clear()
        {
            list.Clear();
            if (OnListCleared != null)
            {
                OnListCleared.Invoke(this);//not much to say when the list is cleared
            }
        }
        public bool Contains(T item) { return list.Contains(item); }
        public void Remove(T item)
        {
            list.Remove(item);
            if (OnItemRemoved != null)//this fires if there are listeners
            {
                OnItemRemoved.Invoke(this, (list.Count + 1, list.Count, item, DateTime.Now));//tuple rules
            }
        }
        public T this[int index] { get => list[index]; set => list[index] = value; }

        public event ItemAddedEventDelegate<T> OnItemAdded; // named delegate here
        public event Action<NoisyList<T>> OnListCleared; // we are using Action<> generic delegate here
        public event Action<NoisyList<T>, (int CountBeforeRemove, int CountAfterRemove, T? ItemRemoved, DateTime RemoveTimestamp)> OnItemRemoved;
        //third one uses a tuple to group event arguments without creating another class like OnItemAddedEventArgs
    }
    // we are using a named delegate here
    public delegate void ItemAddedEventDelegate<T>(NoisyList<T> sender, OnItemAddedEventArgs<T> args);
    //we need to define what is to be expected by the event handler
    public class OnItemAddedEventArgs<T> : EventArgs
    {
        public int CountBeforeAddition { get; set; }
        public int CountAfterAddition { get; set; }
        public T? ItemAdded { get; set; }
        public DateTime InsertionTimestamp { get; set; }
        public int ItemPositionInList { get; set; }
    }

}