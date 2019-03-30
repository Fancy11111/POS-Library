using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public sealed class Singleton
    {
        // The actual Singleton instance
        // Defined as readonly so no overriding is possible
        private static readonly Singleton INSTANCE = new Singleton();

        // Define constructor as private so no outside call can be made
        private Singleton() { }

        // The field that provides access to the singleton instance
        public static Singleton Instance { get { return INSTANCE; } }
    }

    // This is a Singleton implementation in which the singleton instance is created lazily
    // The lazy initialization is thread safe
    public sealed class LazySingleton
    {
        // Lazy<T> contains an object of type T
        // This object is created when Lazy.Value is first called
        // The object is created through the lamba provided in the constructor of the Lazy<T> object
        private static readonly Lazy<LazySingleton> INSTANCE = new Lazy<LazySingleton>(() => new LazySingleton());

        // Define constructor as private so no outside call can be made
        private LazySingleton() { }
        
        // The field that provides access to the singleton instance
        public static LazySingleton Instance { get { return INSTANCE.Value; } }
    }
}
