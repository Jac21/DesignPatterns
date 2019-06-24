using System;

// provides a simplified and uniform interface to a large subsystem of classes.
namespace Facade.StructuralFacade
{
    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("SubsystemOne Method");
        }
    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("SubSystemTwo Method");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("SubSystemThree Method");
        }
    }

    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine("SubSystemFour Method");
        }
    } 

    public class StructuralFacade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public StructuralFacade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            _one.MethodOne();
            _two.MethodTwo();
            _three.MethodThree();
            _four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}
