using System;

namespace Singleton.Lazy
{
    // http://csharpindepth.com/Articles/General/Singleton.aspx
    public sealed class LazySingleton
    {
        // pass a delegate to the constructor which calls the 
        // Singleton constructor - which is done most easily with a lambda expression
        private static readonly Lazy<LazySingleton> Lazy =
            new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton Instance
        {
            get { return Lazy.Value; }
        }

        private LazySingleton() { }

        public bool CheckCreation()
        {
            return Lazy.IsValueCreated;
        }
    }
}
