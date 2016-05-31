using System;
using System.Collections.Generic;

namespace Flyweight.RealWorld
{
    class RealWorldFlyweightFactory
    {
        private Dictionary<char, Character> _characters = 
            new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            // uses "lazy" initializations
            Character character = null;
            if (_characters.ContainsKey(key))
            {
                character = _characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A': 
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;
                    case 'C':
                        character = new CharacterC();
                        break;
                }
                _characters.Add(key, character);
            }
            return character;
        }
    }

    /// <summary>
    /// Abstract Flyweight class
    /// </summary>
    abstract class Character
    {
        protected char Symbol;
        protected int Width;
        protected int Height;
        protected int Ascent;
        protected int Descent;
        protected int PointSize;

        public abstract void Display(int pointSize);
    }

    /// <summary>
    /// Concrete class
    /// </summary>
    class CharacterA : Character
    {
        // Constructor
        public CharacterA()
        {
            this.Symbol = 'A';
            this.Height = 100;
            this.Width = 120;
            this.Ascent = 70;
            this.Descent = 0;
        }

        public override void Display(int pointSize)
        {
            this.PointSize = pointSize;
            Console.WriteLine(this.Symbol + " (pointsize " + this.PointSize + ")");
        }
    }

    /// <summary>
    /// Concrete class
    /// </summary>
    class CharacterB : Character
    {
        // Constructor
        public CharacterB()
        {
            this.Symbol = 'B';
            this.Height = 110;
            this.Width = 190;
            this.Ascent = 60;
            this.Descent = 10;
        }

        public override void Display(int pointSize)
        {
            this.PointSize = pointSize;
            Console.WriteLine(this.Symbol + " (pointsize " + this.PointSize + ")");
        }
    }

    /// <summary>
    /// Concrete class
    /// </summary>
    class CharacterC : Character
    {
        // Constructor
        public CharacterC()
        {
            this.Symbol = 'C';
            this.Height = 200;
            this.Width = 320;
            this.Ascent = 170;
            this.Descent = 10;
        }

        public override void Display(int pointSize)
        {
            this.PointSize = pointSize;
            Console.WriteLine(this.Symbol + " (pointsize " + this.PointSize + ")");
        }
    }

    // etc., etc., etc...
}
