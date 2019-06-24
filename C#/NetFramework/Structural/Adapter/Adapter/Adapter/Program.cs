using System;

namespace Adapter
{
    /// <summary>
    /// Adapter pattern lets you wrap an otherwise incompatible object in an adapter 
    /// to make it compatible with another class.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var wildDog = new WildDog();
            wildDog.Bark();
            var wildDogAdapter = new WildDogAdapter(wildDog);

            var hunter = new Hunter();
            hunter.Hunt(wildDogAdapter);
        }
    }

    /// <summary>
    /// Consider a game where there is a hunter and he hunts lions.
    /// 
    /// First we have an interface Lion that all types of lions have to implement
    /// </summary>
    public interface ILion
    {
        void Roar();
    }

    public class AfricanLion : ILion
    {
        public void Roar()
        {
            Console.WriteLine($"{GetType()} yelped!");
        }
    }

    public class AsianLion : ILion
    {
        public void Roar()
        {
            Console.WriteLine($"{GetType()} yelped!");
        }
    }

    /// <summary>
    /// A Hunter expects any implementation of Lion interface to hunt.
    /// </summary>
    public class Hunter
    {
        public void Hunt(ILion lion)
        {
            Console.WriteLine($"{lion.GetType()} hunted!");
        }
    }

    // This needs to be added to the game
    public class WildDog
    {
        public void Bark()
        {
            Console.WriteLine($"{GetType()} borked!");
        }
    }

    // Adapter around wild dog to make it compatible with our game
    public class WildDogAdapter : ILion
    {
        private readonly WildDog dog;

        public WildDogAdapter(WildDog dog)
        {
            this.dog = dog;
        }

        public void Roar()
        {
            dog.Bark();
        }
    }
}