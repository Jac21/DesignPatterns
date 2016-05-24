using AbstractFactory.Structural;
using AbstractFactory.RealWorld;

//Provide an interface for creating families of related or dependent 
// objects without specifying their concrete classes.

namespace AbstractFactory
{

    /*
     *    The classes and objects participating in this pattern are:

     * AbstractFactory  (ContinentFactory)
        declares an interface for operations that create abstract products

     * ConcreteFactory   (AfricaFactory, AmericaFactory)
        implements the operations to create concrete product objects

     * AbstractProduct   (Herbivore, Carnivore)
        declares an interface for a type of product object

     * Product  (Wildebeest, Lion, Bison, Wolf)
    defines a product object to be created by the corresponding concrete factory
    implements the AbstractProduct interface

     * Client  (AnimalWorld)
        uses interfaces declared by AbstractFactory and AbstractProduct classes
     */

    class Program
    {
        static void Main()
        {
            /*
             * Structural
             */

            StructuralAbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            StructuralAbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            /*
             * Real World
             */

            AfricaFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            RealWorldAbstractFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
    }
}
