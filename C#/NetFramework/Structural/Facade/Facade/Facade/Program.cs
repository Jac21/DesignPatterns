// Provide a unified interface to a set of interfaces in a subsystem. 
// Façade defines a higher-level interface that makes the subsystem easier to use.

using System;

namespace Facade
{
    /*
     * Facade   (MortgageApplication)
        knows which subsystem classes are responsible for a request.
        delegates client requests to appropriate subsystem objects.

     * Subsystem classes   (Bank, Credit, Loan)
        implement subsystem functionality.
        handle work assigned by the Facade object.
        have no knowledge of the facade and keep no reference to it.
     */

    class Program
    {
        static void Main()
        {
            /*
             *  Structural implementation
             */

            // Facade
            StructuralFacade.StructuralFacade structuralFacade = new StructuralFacade.StructuralFacade();

            structuralFacade.MethodA();
            structuralFacade.MethodB();

            /*
             *  Real-World implementation
             */

            // Facade
            RealWorldFacade.RealWorldFacade realWorldFacade = new RealWorldFacade.RealWorldFacade();

            // evaluate mortage eligibility for customer
            RealWorldFacade.Customer customer = new RealWorldFacade.Customer("Jeremy Cantu");
            bool eligible = realWorldFacade.IsEligible(customer, 100000);

            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }
}
