using System;

namespace AbstractFactory.Structural
{
    /// <summary>
    /// 'AbstractFactory' abstract class
    /// </summary>
    abstract class StructuralAbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    /// <summary>
    /// 'ConcreteFactory1' class
    /// </summary>
    class ConcreteFactory1 : StructuralAbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    /// <summary>
    /// 'ConcreteFactory1' class
    /// </summary>
    class ConcreteFactory2 : StructuralAbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    abstract class AbstractProductA { }

    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    class ProductA1 : AbstractProductA
    {
         
    }

    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
                " interacts with " + a.GetType().Name);
        }
    }

    class ProductA2 : AbstractProductA
    {
        
    }

    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name +
                " interacts with " + a.GetType().Name);
        }
    }

    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        // Constructor
        public Client(StructuralAbstractFactory factory)
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}
