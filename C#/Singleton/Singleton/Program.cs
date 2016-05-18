using System;
using Singleton.Structural;
using Singleton.RealWorld;
using Singleton.DotNetOptimized;
using Singleton.Lazy;

// Ensure a class has only one instance and provide a global point of access to it.
namespace Singleton
{
    class Program
    {
        static void Main()
        {
            /*
             * Structural
             */

            // constructors are protected, cannot use "new"
            StructuralSingleton structuralSingletonOne = StructuralSingleton.Instance();
            StructuralSingleton structuralSingletonTwo = StructuralSingleton.Instance();

            // test for instance equality
            if (structuralSingletonOne == structuralSingletonTwo)
            {
                Console.WriteLine("Objects are same instance");
            }

            /*
             * Real-World
             */

            RealWorldSingletonLoadBalancer balancerOne = RealWorldSingletonLoadBalancer.GetLoadBalancer();
            RealWorldSingletonLoadBalancer balancerTwo = RealWorldSingletonLoadBalancer.GetLoadBalancer();
            RealWorldSingletonLoadBalancer balancerThree = RealWorldSingletonLoadBalancer.GetLoadBalancer();
            RealWorldSingletonLoadBalancer balancerFour = RealWorldSingletonLoadBalancer.GetLoadBalancer();

            // test for equality
            if (balancerOne == balancerTwo && balancerTwo == balancerThree && balancerThree == balancerFour)
            {
                Console.WriteLine("Same instance");
            }

            // load balance 15 server requests
            RealWorldSingletonLoadBalancer loadBalancer = RealWorldSingletonLoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = loadBalancer.Server;
                Console.WriteLine("Dispatch request to: " + server);
            }

            /*
             * .NET Optimized
             */

            DotNetOptimizedSingleton dotNetBalancerOne = DotNetOptimizedSingleton.GetLoadBalancer();
            DotNetOptimizedSingleton dotNetBalancerTwo = DotNetOptimizedSingleton.GetLoadBalancer();
            DotNetOptimizedSingleton dotNetBalancerThree = DotNetOptimizedSingleton.GetLoadBalancer();
            DotNetOptimizedSingleton dotNetBalancerFour = DotNetOptimizedSingleton.GetLoadBalancer();

            // test for equality
            if (dotNetBalancerOne == dotNetBalancerTwo && dotNetBalancerTwo == 
                dotNetBalancerThree && dotNetBalancerThree == dotNetBalancerFour)
            {
                Console.WriteLine("Same instance");
            }

            // load balance 15 server requests
            DotNetOptimizedSingleton dotNetBalancer = DotNetOptimizedSingleton.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = dotNetBalancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: " + server);
            }

            /*
             * Lazy
             */

            LazySingleton lazySingletonOne = LazySingleton.Instance;
            LazySingleton lazySingletonTwo = LazySingleton.Instance;

            if (lazySingletonOne == lazySingletonTwo)
            {
                Console.WriteLine("Lazy Singletons are equal");
            }

            Console.WriteLine(lazySingletonOne.CheckCreation());
        }
    }
}
