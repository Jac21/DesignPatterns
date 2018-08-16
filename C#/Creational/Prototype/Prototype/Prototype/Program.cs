using System;

namespace Prototype
{
    /// <summary>
    /// Create object based on an existing object through cloning.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            // When an object is required that is similar to existing object or 
            // when the creation would be expensive as compared to cloning.

            var original = new Sheep("Jeremy", "Not a sheep, yo");
            Console.WriteLine($"Name: {original.Name}");
            Console.WriteLine($"Category: {original.Category}");

            var cloned = original.Clone();
            cloned.Name = "Dolly";
            Console.WriteLine($"Name: {cloned.Name}");
            Console.WriteLine($"Category: {cloned.Category}");
            Console.WriteLine($"Name: {original.Name}");
        }
    }

    /// <summary>
    /// In C#, it can be easily done using MemberwiseClone()
    /// </summary>
    public class Sheep
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Sheep(string name, string category)
        {
            Name = name;
            Category = category;
        }

        public Sheep Clone()
        {
            return MemberwiseClone() as Sheep;
        }
    }
}