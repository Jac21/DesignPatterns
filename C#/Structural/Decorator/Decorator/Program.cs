using System;
using Decorator.Structural;
using Decorator.RealWorld;

// Attach additional responsibilities to an object dynamically. 
// Decorators provide a flexible alternative to subclassing for extending functionality.
namespace Decorator
{
    /*
     * The classes and objects participating in this pattern are:

     * Component   (LibraryItem)
        defines the interface for objects that can have responsibilities 
        added to them dynamically.
        
     * ConcreteComponent   (Book, Video)
        defines an object to which additional responsibilities can be attached.
        
     * Decorator   (Decorator)
        maintains a reference to a Component object and defines an interface that conforms 
        to Component's interface.
        
     * ConcreteDecorator   (Borrowable)
        adds responsibilities to the component.
     */

    class Program
    {
        static void Main()
        {
            /*
             * Structural
             */

            // Create ConcreteComponent and two Decorators
            StructuralConcreteComponent c = new StructuralConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            // Link Decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            // Call decorators operation
            d2.Operation();

            /*
             * Real World
             */

            // Create a book
            Book book = new Book("Cantu, Jeremy", "My Life as a Person", 12345);
            book.Display();

            // Create a video
            Video video = new Video("Tarantino, Quentin", "Jeremy's Life", 54321, 60);
            video.Display();

            // Make video borrow-able, then borrow and display
            Console.WriteLine("Making video borrow-able");

            Borrowable borrowableVideo = new Borrowable(video);
            borrowableVideo.BorrowItem("Customer #1");
            borrowableVideo.BorrowItem("Customer #2");

            borrowableVideo.Display();
        }
    }
}
