using System;

namespace AbstractFactory.RealWorld
{
    /// <summary>
    /// 'AbstractFactory' class
    /// </summary>
    abstract class RealWorldAbstractFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    /// <summary>
    /// 'ConcreteFactory1' class
    /// </summary>
    class AfricaFactory : RealWorldAbstractFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildbeast();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }

    /// <summary>
    /// 'ConcreteFactory2' class
    /// </summary>
    class AmericaFactory : RealWorldAbstractFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    /// <summary>
    /// 'AbstractProductA' abstract class
    /// </summary>
    abstract class Herbivore { }

    /// <summary>
    /// 'AbstractProductB' abstract class
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    /// 'ProductA1' class
    /// </summary>
    class Wildbeast : Herbivore { }

    /// <summary>
    /// 'ProductB1' class
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // eat wildbeast
            Console.WriteLine(this.GetType().Name +
                " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// 'ProductA2' class
    /// </summary>
    class Bison : Herbivore { }

    /// <summary>
    /// 'ProductB2' class
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // eat wildbeast
            Console.WriteLine(this.GetType().Name +
                " eats " + h.GetType().Name);
        }
    }

    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        // Constructor
        public AnimalWorld(RealWorldAbstractFactory abstractFactory)
        {
            _carnivore = abstractFactory.CreateCarnivore();
            _herbivore = abstractFactory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
