using System;
using System.Collections.Generic;

namespace Decorator.RealWorld
{
    /// <summary>
    /// 'Component' abstract class
    /// </summary>
    abstract class LibraryItem
    {
        private int _numCopies;

        // Property
        public int NumCopies
        {
            get { return _numCopies; }
            set { _numCopies = value; }
        }

        public abstract void Display();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        // Constructor
        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook-----------");
            Console.WriteLine("Author: {0}", _author);
            Console.WriteLine("Title: {0}", this._title);
            Console.WriteLine("# Copies: {0}", NumCopies);
        }
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        // Constructor
        public Video(string director, string title,
          int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    abstract class RealWorldDecorator : LibraryItem
    {
        protected LibraryItem LibraryItem;

        // Constructor
        public RealWorldDecorator(LibraryItem libraryItem)
        {
            this.LibraryItem = libraryItem;
        }

        public override void Display()
        {
            LibraryItem.Display();
        }
    }

    /// <summary>
    /// The 'ConcreteDecorator' class
    /// </summary>
    class Borrowable : RealWorldDecorator
    {
         protected List<string> BorrowerList = new List<string>();
 
        // Constructor
        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {
            
        }

        public void BorrowItem(string name)
        {
            BorrowerList.Add(name);
            LibraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            BorrowerList.Remove(name);
            LibraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach (string borrower in BorrowerList)
            {
                Console.WriteLine("Borrower: " + borrower);
            }
        }
    }
}
