using System;
using System.Collections;

// Concrete collection class
class MyCollection : IEnumerable
{
    private int[] items;

    public MyCollection(int[] arr)
    {
        items = arr;
    }

    public IEnumerator GetEnumerator()
    {
        // Returns a new instance of the custom iterator class
        return new MyIterator(items);
    }
}

// Custom iterator class
class MyIterator : IEnumerator
{
    private int[] items;
    private int position = -1;

    public MyIterator(int[] arr)
    {
        items = arr;
    }

    public object Current
    {
        get
        {
            return items[position];
        }
    }

    public bool MoveNext()
    {
        // Move to the next item in the collection
        position++;

        // Return true if there are still items to iterate over
        return position < items.Length;
    }

    public void Reset()
    {
        // Reset the iterator to its initial state
        position = -1;
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 2, 3, 4, 5 };

        // Create a new instance of the collection class
        MyCollection collection = new MyCollection(arr);

        // Iterate over the collection using foreach
        foreach (int item in collection)
        {
            Console.WriteLine(item);
        }
    }
}
