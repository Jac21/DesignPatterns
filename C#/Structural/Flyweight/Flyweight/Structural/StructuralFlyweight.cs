using System;
using System.Collections;

namespace Flyweight.Structural
{
    /// <summary>
    /// Creates and manages flyweight objects.
    /// </summary>
    class StructuralFlyweightFactory
    {
        private readonly Hashtable _flyweights = new Hashtable();

        // constructor
        public StructuralFlyweightFactory()
        {
            this._flyweights.Add("X", new ConcreteFlyweight());
            this._flyweights.Add("Y", new ConcreteFlyweight());
            this._flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return ((Flyweight) this._flyweights[key]);
        }
    }

    /// <summary>
    /// Flyweight abstract class
    /// </summary>
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }

    /// <summary>
    /// Concrete class, implements the Flyweight interface and adds storage for 
    /// intrinsic state.
    /// </summary>
    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicState)
        {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicState);
        }
    }

    /// <summary>
    /// Unshared concrete class, not all Flyweight subclasses need to be shared.
    /// </summary>
    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicState)
        {
            Console.WriteLine("UnsharedConcreteFlyweight: " + extrinsicState);
        }
    }
}
