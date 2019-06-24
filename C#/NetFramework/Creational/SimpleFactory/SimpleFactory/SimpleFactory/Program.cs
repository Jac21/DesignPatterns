using System;

namespace SimpleFactory
{
    /// <summary>
    /// Simple factory simply generates an instance for client without exposing any instantiation logic to the client
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var door = DoorFactory.MakeDoor(80, 30);
            Console.WriteLine($"Height of Door: {door.GetHeight()}");
            Console.WriteLine($"Width of Door: {door.GetWidth()}");
        }
    }

    public interface IDoor
    {
        int GetHeight();
        int GetWidth();
    }

    public class WoodenDoor : IDoor
    {
        private int Height { get; }
        private int Width { get; }

        public WoodenDoor(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int GetHeight()
        {
            return Height;
        }

        public int GetWidth()
        {
            return Width;
        }
    }

    /// <summary>
    /// When to Use?
    /// When creating an object is not just a few assignments and involves some logic, it makes sense to put it in a dedicated factory 
    /// instead of repeating the same code everywhere.
    /// </summary>
    public static class DoorFactory
    {
        public static IDoor MakeDoor(int height, int width)
        {
            return new WoodenDoor(height, width);
        }
    }
}