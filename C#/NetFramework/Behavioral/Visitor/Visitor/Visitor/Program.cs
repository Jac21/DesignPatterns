using System;

namespace Visitor
{
    /// <summary>
    /// Visitor pattern lets you add further operations to objects without having to modify them.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var monkey = new Monkey();
            var lion = new Lion();
            var dolphin = new Dolphin();

            var speak = new Speak();
            var jump = new Jump();

            monkey.Accept(speak);
            monkey.Accept(jump);

            lion.Accept(speak);
            lion.Accept(jump);

            dolphin.Accept(speak);
            dolphin.Accept(jump);
        }
    }

    // Let's take an example of a zoo simulation where we have several different kinds of animals and we have to make them Sound. 
    // Let's translate this using visitor pattern

    /// <summary>
    /// Visitee
    /// </summary>
    public interface IAnimal
    {
        void Accept(IAnimalOperation operation);
    }

    /// <summary>
    /// Visitor
    /// </summary>
    public interface IAnimalOperation
    {
        void VisitMonkey(Monkey monkey);

        void VisitLion(Lion lion);

        void VisitDolphin(Dolphin dolphin);
    }

    public class Monkey : IAnimal
    {
        public void Shout()
        {
            Console.WriteLine("screech");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitMonkey(this);
        }
    }

    public class Lion : IAnimal
    {
        public void Shout()
        {
            Console.WriteLine("roar");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitLion(this);
        }
    }

    public class Dolphin : IAnimal
    {
        public void Shout()
        {
            Console.WriteLine("thanks");
        }

        public void Accept(IAnimalOperation operation)
        {
            operation.VisitDolphin(this);
        }
    }

    /// <summary>
    /// Let's implement our visitor
    /// </summary>
    public class Speak : IAnimalOperation
    {
        public void VisitMonkey(Monkey monkey)
        {
            monkey.Shout();
        }

        public void VisitLion(Lion lion)
        {
            lion.Shout();
        }

        public void VisitDolphin(Dolphin dolphin)
        {
            dolphin.Shout();
        }
    }

    /// <summary>
    /// We could have done this simply by having an inheritance hierarchy for the animals but then 
    /// we would have to modify the animals whenever we would have to add new actions to animals. 
    /// But now we will not have to change them. For example, let's say we are asked to add the jump 
    /// behavior to the animals, we can simply add that by creating a new visitor i.e.
    /// </summary>
    public class Jump : IAnimalOperation
    {
        public void VisitDolphin(Dolphin dolphin)
        {
            Console.WriteLine("Walked on water a little and disappeared!");
        }

        public void VisitLion(Lion lion)
        {
            Console.WriteLine("Jumped 7 feet! Back on the ground!");
        }

        public void VisitMonkey(Monkey monkey)
        {
            Console.WriteLine("Jumped 20 feet high! on to the tree!");
        }
    }
}