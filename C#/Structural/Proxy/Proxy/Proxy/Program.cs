using System;

namespace Proxy
{
    /// <summary>
    /// Using the proxy pattern, a class represents the functionality of another class.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var door = new SecuredDoor(new LabDoor());
            door.Open("hunter2");
            door.Close();

            door.Open("$3CRET");
            door.Close();
        }
    }

    /// <summary>
    /// Firstly we have the door interface and an implementation of door
    /// </summary>
    public interface IDoor
    {
        bool IsDoorOpen { get; set; }
        bool IsDoorClosed { get; set; }

        void Open();
        void Close();
    }

    class LabDoor : IDoor
    {
        public bool IsDoorOpen { get; set; }
        public bool IsDoorClosed { get; set; }

        public LabDoor()
        {
            IsDoorOpen = false;
            IsDoorClosed = true;
        }

        public void Open()
        {
            IsDoorOpen = true;
            IsDoorClosed = false;
            Console.WriteLine("Opening lab door");
        }

        public void Close()
        {
            IsDoorOpen = false;
            IsDoorClosed = true;
            Console.WriteLine("Closing lab door");
        }
    }

    // Then we have a proxy to secure any doors that we want
    public class SecuredDoor
    {
        private readonly IDoor door;

        public SecuredDoor(IDoor door)
        {
            this.door = door ?? throw new ArgumentNullException(nameof(door), "door cannot be null");
        }

        public void Open(string password)
        {
            if (Authenticate(password) && !door.IsDoorOpen)
            {
                door.Open();
            }
            else
            {
                Console.WriteLine("Door is already open or incorrect password entered!");
            }
        }

        private bool Authenticate(string password)
        {
            return password == "$3CRET";
        }

        public void Close()
        {
            if (!door.IsDoorClosed)
            {
                door.Close();
            }
            else
            {
                Console.WriteLine("Door is already closed!");
            }
        }
    }
}