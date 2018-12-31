// The singleton design pattern is achieved by having a private constructor
// along with a private (static) instance variable and a public (static)
// class-level 'GetInstance()' method.

using System;

namespace GangOfFour.Creational
{
    class Singleton
    {
        private static Singleton _instance;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (_instance == null)
                _instance = new Singleton();

            return _instance;
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
                Console.WriteLine("Objects are the same!");
        }
    }
}
