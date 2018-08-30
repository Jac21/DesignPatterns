using System;

namespace Command
{
    /// <summary>
    /// Allows you to encapsulate actions in objects. The key idea behind this pattern is to provide the means to decouple client from receiver.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var bulb = new Bulb();

            var turnOn = new TurnOn(bulb);
            var turnOff = new TurnOff(bulb);

            var remote = new RemoteControl();
            remote.Submit(turnOn);
            remote.Submit(turnOff);

            Console.ReadLine();
        }
    }

    /// <summary>
    /// First of all we have the receiver that has the implementation of every action that could be performed - 
    /// Receiver
    /// </summary>
    public class Bulb
    {
        public void TurnOn()
        {
            Console.WriteLine("Bulb has been lit.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Bulb has been de-lit.");
        }
    }

    /// <summary>
    /// then we have an interface that each of the commands are going to implement and then we have a set of commands
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }

    /// <summary>
    /// Command
    /// </summary>
    public class TurnOn : ICommand
    {
        private readonly Bulb bulb;

        public TurnOn(Bulb bulb)
        {
            this.bulb = bulb ?? throw new ArgumentNullException(nameof(bulb));
        }

        public void Execute()
        {
            bulb.TurnOn();
        }

        public void Undo()
        {
            bulb.TurnOff();
        }

        public void Redo()
        {
            Execute();
        }
    }

    /// <summary>
    /// Command
    /// </summary>
    public class TurnOff : ICommand
    {
        private readonly Bulb bulb;

        public TurnOff(Bulb bulb)
        {
            this.bulb = bulb ?? throw new ArgumentNullException(nameof(bulb));
        }

        public void Execute()
        {
            bulb.TurnOff();
        }

        public void Undo()
        {
            bulb.TurnOn();
        }

        public void Redo()
        {
            Execute();
        }
    }

    /// <summary>
    /// Then we have an Invoker with whom the client will interact to process any commands
    /// </summary>
    public class RemoteControl
    {
        public void Submit(ICommand command)
        {
            command.Execute();
        }
    }
}