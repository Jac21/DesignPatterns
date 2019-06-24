using System;

namespace Decorator.Structural
{
    /// <summary>
    /// 'Component' abstract class
    /// </summary>
    abstract class StructuralComponent
    {
        public abstract void Operation();
    }

    class StructuralConcreteComponent : StructuralComponent
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    /// <summary>
    /// 'Decorator' abstract class
    /// </summary>
    abstract class StructuralDecorator : StructuralComponent
    {
        protected StructuralComponent Component;

        public void SetComponent(StructuralComponent component)
        {
            this.Component = component;
        }

        public override void Operation()
        {
            if (Component != null)
            {
                Component.Operation();
            }
        }
    }

    /// <summary>
    /// Concrete Decorator 'A' Class
    /// </summary>
    class ConcreteDecoratorA : StructuralDecorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    /// <summary>
    /// Concrete Decorator 'B' Class
    /// </summary>
    class ConcreteDecoratorB : StructuralDecorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        void AddedBehavior()
        {
            
        }
    }
}
