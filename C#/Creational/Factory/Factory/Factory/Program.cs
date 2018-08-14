using System;

namespace Factory
{
    /// <summary>
    /// It provides a way to delegate the instantiation logic to child classes.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var developerManager = new DevelopmentManager();
            developerManager.GiveInterview();

            var architectManager = new ArchitectManager();
            architectManager.GiveInterview();
        }
    }

    public interface IInterviewer
    {
        void AskQuestions();
    }

    public class Developer : IInterviewer
    {
        public void AskQuestions()
        {
            Console.WriteLine("Asking about design patterns!");
        }
    }

    public class Architect : IInterviewer
    {
        public void AskQuestions()
        {
            Console.WriteLine("Asking about architecture questions!");
        }
    }

    /// <summary>
    /// In class-based programming, the factory method pattern is a creational pattern that uses factory methods to deal with the problem of 
    /// creating objects without having to specify the exact class of the object that will be created. This is done by creating objects by 
    /// calling a factory method—either specified in an interface and implemented by child classes, or implemented in a base class and 
    /// optionally overridden by derived classes—rather than by calling a constructor.
    /// </summary>
    abstract class HiringManager
    {
        // Factory method
        protected abstract IInterviewer MakeInterviewer();

        public void GiveInterview()
        {
            var interviewer = MakeInterviewer();
            interviewer.AskQuestions();
        }
    }

    /// <summary>
    /// Useful when there is some generic processing in a class but the required sub-class is dynamically decided at runtime.
    ///  Or putting it in other words, when the client doesn't know what exact sub-class it might need.
    /// </summary>
    class DevelopmentManager : HiringManager
    {
        protected override IInterviewer MakeInterviewer()
        {
            return new Developer();
        }
    }

    class ArchitectManager : HiringManager
    {
        protected override IInterviewer MakeInterviewer()
        {
            return new Architect();
        }
    }
}