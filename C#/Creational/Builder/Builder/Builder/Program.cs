using System;
using System.Text;

namespace Builder
{
    /// <summary>
    /// Allows you to create different flavors of an object while avoiding constructor pollution. 
    /// Useful when there could be several flavors of an object. Or when there are a lot of steps involved in creation of an object.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// When there could be several flavors of an object and to avoid the constructor telescoping. 
        /// The key difference from the factory pattern is that; factory pattern is to be used when 
        /// the creation is a one step process while builder pattern is to be used when the creation is a multi step process.
        /// </summary>
        private static void Main()
        {
            var burger = new BurgerBuilder(4).AddCheese().AddPepperoni().AddLettuce().AddTomato().Build();
            Console.WriteLine(burger.GetDescription());
        }
    }

    /// <summary>
    /// First of all we have our burger that we want to make
    /// </summary>
    public class Burger
    {
        private readonly int mSize;
        private bool mCheese;
        private bool mPepperoni;
        private bool mLettuce;
        private bool mTomato;

        public Burger(BurgerBuilder builder)
        {
            mSize = builder.Size;
            mCheese = builder.Cheese;
            mPepperoni = builder.Pepperoni;
            mLettuce = builder.Lettuce;
            mTomato = builder.Tomato;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            sb.Append($"This is an {mSize} inch burger.");
            return sb.ToString();
        }
    }

    /// <summary>
    /// And then we have the builder
    /// </summary>
    public class BurgerBuilder
    {
        public int Size;
        public bool Cheese;
        public bool Pepperoni;
        public bool Lettuce;
        public bool Tomato;

        public BurgerBuilder(int size)
        {
            Size = size;
        }

        public BurgerBuilder AddCheese()
        {
            Cheese = true;
            return this;
        }

        public BurgerBuilder AddPepperoni()
        {
            Pepperoni = true;
            return this;
        }

        public BurgerBuilder AddLettuce()
        {
            Lettuce = true;
            return this;
        }

        public BurgerBuilder AddTomato()
        {
            Tomato = true;
            return this;
        }

        public Burger Build()
        {
            return new Burger(this);
        }
    }
}