using System;

namespace Mediator.Structural
{
    // Mediator abstract class
    public abstract class StructuralMediator
    {
        public abstract void Send(string message, StructuralColleague structuralColleague);
    }

    // Concrete Mediator class
    public class StructuralConcreteMediator : StructuralMediator
    {
        private StructuralConcreteColleague1 _colleague1;
        private StructuralConcreteColleague2 _colleague2;

        public StructuralConcreteColleague1 Colleague1
        {
            set { _colleague1 = value; }
        }

        public StructuralConcreteColleague2 Colleague2
        {
            set { _colleague2 = value; }
        }

        public override void Send(string message, StructuralColleague structuralColleague)
        {
            if (structuralColleague == _colleague1)
            {
                _colleague2.Notify(message);
            }
            else
            {
                _colleague1.Notify(message);
            }
        }
    }

    // StructuralColleague abstract class
    public abstract class StructuralColleague
    {
        protected StructuralMediator Mediator;

        // constructor
        public StructuralColleague(StructuralMediator mediator)
        {
            this.Mediator = mediator;
        }
    }

    // A ConcreteColleague class
    public class StructuralConcreteColleague1 : StructuralColleague
    {
        // constructor
        public StructuralConcreteColleague1(StructuralMediator mediator)
            : base(mediator)
        {

        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: " + message);
        }
    }

    // A ConcreteColleague class
    public class StructuralConcreteColleague2 : StructuralColleague
    {
        // constructor
        public StructuralConcreteColleague2(StructuralMediator mediator)
            : base(mediator)
        {
            
        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: " + message);
        }
    }
}
