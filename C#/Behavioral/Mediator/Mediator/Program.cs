using System.Collections.Generic;
using Mediator.Structural;
using Mediator.RealWorld;

// Define an object that encapsulates how a set of objects interact. 
// Mediator promotes loose coupling by keeping objects from referring to 
// each other explicitly, and it lets you vary their interaction independently.
namespace Mediator
{
    // The classes and objects participating in this pattern are:
    // Mediator: defines an interface for communicating

    // StructuralConcreteMediator: implements cooperative behavior by coordinating
    // objects, knows and maintains those objects

    // StructuralColleague classes: each class knows its Mediator objects
    // as well as communicates with its mediator whenever it would have
    // otherwise communicated with another
    class Program
    {
        static void Main()
        {
            /*
             * Structural Mediator
             */ 
            StructuralConcreteMediator m = new StructuralConcreteMediator();

            StructuralConcreteColleague1 c1 = new StructuralConcreteColleague1(m);
            StructuralConcreteColleague2 c2 = new StructuralConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Find, thanks");

            /*
             *  Real-World Mediator
             */

            Chatroom chatroom = new Chatroom();

            Participant george = new Beatle("George");
            Participant paul = new Beatle("Paul");
            Participant ringo = new Beatle("Ringo");
            Participant john = new Beatle("John");
            Participant yoko = new NonBeatle("Yoko");

            List<Participant> participantList = new List<Participant>()
            {
                george, paul, ringo, john, yoko
            };

            foreach (var beatle in participantList)
            {
                chatroom.Register(beatle);
            }

            // Chatting participants
            yoko.Send("John", "Hi John!");
            paul.Send("Ringo", "All you need is love");
            ringo.Send("George", "My sweet Lord");
            paul.Send("John", "Can't buy me love");
            john.Send("Yoko", "My sweet love");
        }
    }
}
