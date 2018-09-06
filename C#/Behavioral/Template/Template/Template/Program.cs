using System;

namespace Template
{
    /// <summary>
    /// Template method defines the skeleton of how a certain algorithm could be performed, 
    /// but defers the implementation of those steps to the children classes.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var androidBuilder = new AndroidBuilder();
            androidBuilder.Build();

            var iosBuilder = new IosBuilder();
            iosBuilder.Build();
        }
    }

    /// <summary>
    /// First of all we have our base class that specifies the skeleton for the build algorithm
    /// </summary>
    public abstract class Builder
    {
        public abstract void Test();
        public abstract void Lint();
        public abstract void Assemble();
        public abstract void Deploy();

        // Template method
        public void Build()
        {
            Test();
            Lint();
            Assemble();
            Deploy();
        }
    }

    /// <summary>
    /// Then we can have our implementations
    /// </summary>
    public class AndroidBuilder : Builder
    {
        public override void Test()
        {
            Console.WriteLine("Running android tests");
        }

        public override void Lint()
        {
            Console.WriteLine("Linting the android code");
        }

        public override void Assemble()
        {
            Console.WriteLine("Assembling the android build");
        }

        public override void Deploy()
        {
            Console.WriteLine("Deploying android build to server");
        }
    }


    public class IosBuilder : Builder
    {
        public override void Test()
        {
            Console.WriteLine("Running ios tests");
        }

        public override void Lint()
        {
            Console.WriteLine("Linting the ios code");
        }

        public override void Assemble()
        {
            Console.WriteLine("Assembling the ios build");
        }

        public override void Deploy()
        {
            Console.WriteLine("Deploying ios build to server");
        }
    }
}