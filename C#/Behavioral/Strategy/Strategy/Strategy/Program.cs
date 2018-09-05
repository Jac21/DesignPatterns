using System;
using System.Collections.Generic;

namespace Strategy
{
    /// <summary>
    /// Strategy pattern allows you to switch the algorithm or strategy based upon the situation.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var unSortedList = new List<int> {1, 10, 2, 16, 19};

            var sorter = new Sorter(new BubbleSortStrategy());
            sorter.Sort(unSortedList);

            sorter = new Sorter(new QuickSortStrategy());
            sorter.Sort(unSortedList);
        }
    }

    /// <summary>
    /// First of all we have our strategy interface and different strategy implementations
    /// </summary>
    public interface ISortStrategy
    {
        List<int> Sort(List<int> dataset);
    }

    public class BubbleSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> dataset)
        {
            Console.WriteLine("Sorting using Bubble Sort!");
            return dataset;
        }
    }

    public class QuickSortStrategy : ISortStrategy
    {
        public List<int> Sort(List<int> dataset)
        {
            Console.WriteLine("Sorting using Quick Sort!");
            return dataset;
        }
    }

    /// <summary>
    /// And then we have our client that is going to use any strategy
    /// </summary>
    public class Sorter
    {
        private readonly ISortStrategy sorter;

        public Sorter(ISortStrategy sorter)
        {
            this.sorter = sorter;
        }

        public List<int> Sort(List<int> unsortedList)
        {
            return sorter.Sort(unsortedList);
        }
    }
}