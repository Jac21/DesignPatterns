using System;
using System.Collections.Generic;

namespace Mediator.RealWorld
{
    /// <summary>
    /// Mediator abstract class
    /// </summary>
    public abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }

    /// <summary>
    /// Concrete Mediator
    /// </summary>
    public class Chatroom : AbstractChatroom
    {
        private readonly Dictionary<string, Participant> _participants = 
            new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }

            participant.Chatroom = this;
        }

        public override void Send(
            string from, string to, string message)
        {
            Participant participant = _participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    public class Participant
    {
        private Chatroom _chatroom;
        private readonly string _name;

        // Constructor
        public Participant(string name)
        {
            this._name = name;
        }

        // Gets participant name
        public string Name
        {
            get { return _name; }
        }

        // Gets chatroom
        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }

        // Sends message to given participant
        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        // Receives message from given participant
        public virtual void Receive(
          string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
              from, Name, message);
        }
    }

    /// <summary>
    /// Concrete Colleague Class
    /// </summary>
    public class Beatle : Participant
    {
        public Beatle(string name) 
            : base(name)
        {
            
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// Concrete Colleague Class
    /// </summary>
    public class NonBeatle : Participant
    {
        public NonBeatle(string name) 
            : base(name)
        {
            
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
