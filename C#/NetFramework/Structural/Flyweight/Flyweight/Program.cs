using Flyweight.RealWorld;
using Flyweight.Structural;

// Use sharing to support large numbers of fine-grained objects efficiently.
namespace Flyweight
{
    /*
     * Flyweight   (Character)
     * declares an interface through which flyweights can receive and act on 
     * extrinsic state.

     * ConcreteFlyweight   (CharacterA, CharacterB, ..., CharacterZ)
     * implements the Flyweight interface and adds storage for intrinsic state, 
     * if any. A ConcreteFlyweight object must be sharable. Any state it stores 
     * must be intrinsic, that is, it must be independent of the ConcreteFlyweight 
     * object's context.

     * UnsharedConcreteFlyweight   ( not used )
     * not all Flyweight subclasses need to be shared. The Flyweight interface 
     * enables sharing, but it doesn't enforce it. It is common for 
     * UnsharedConcreteFlyweight objects to have ConcreteFlyweight objects as 
     * children at some level in the flyweight object structure (as the Row and 
     * Column classes have).

     * FlyweightFactory   (CharacterFactory)
     * creates and manages flyweight objects ensures that flyweight are shared 
     * properly. When a client requests a flyweight, the FlyweightFactory objects 
     * assets an existing instance or creates one, if none exists.

     * Client   (FlyweightApp)
     * maintains a reference to flyweight(s). computes or stores the extrinsic 
     * state of flyweight(s).
     */
    class Program
    {
        static void Main()
        {
            /*
             *  Structural Flyweight usage
             */

            int extrinsicState = 21;

            StructuralFlyweightFactory factory = new StructuralFlyweightFactory();

            // work with different flyweight instances
            Structural.Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicState);

            Structural.Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicState);

            Structural.Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicState);

            UnsharedConcreteFlyweight fUnshared = new UnsharedConcreteFlyweight();
            fUnshared.Operation(--extrinsicState);

            /*
             *  Real-World flyweight
             */

            // Build a document with text
            string document = "AACCBBCB";
            char[] chars = document.ToCharArray();

            RealWorldFlyweightFactory characterFactory = new RealWorldFlyweightFactory();

            // extrinsic state
            int pointSize = 10;

            // for each character, use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                Character character = characterFactory.GetCharacter(c);
                character.Display(pointSize);
            }
        }
    }
}
