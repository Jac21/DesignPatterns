using System.Diagnostics;

namespace Mediator
{
    public interface INotifier
    {
        void Notify();

        /// <summary>
        /// Conditional Handler
        /// </summary>
        /// <returns></returns>
        bool CanRun();
    }

    public class NotifierOne : INotifier
    {
        public void Notify()
        {
            Debug.WriteLine($"Debugging from {nameof(NotifierOne)}");
        }

        public bool CanRun()
        {
            //Check something. And return True if it can run. 
            return true;
        }

    }

    public class NotifierTwo : INotifier
    {
        public void Notify()
        {
            Debug.WriteLine($"Debugging from {nameof(NotifierTwo)}");
        }

        public bool CanRun()
        {
            //Check something. And return True if it can run. 
            return false;
        }
    }
}