using System;

namespace GangOfFour.Creational
{
    //--- Ensure a class has only one instance and provide a global point of access to it.

    internal static class Usage
    {
        internal static void UsageMethod()
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            Console.WriteLine(s1.Equals(s2));
        }
    }

    public class Singleton
    {
        private static volatile Singleton instance;
        private readonly static object syncRoot = new Object();

        //--- C'tor is non public, so can't be instantiated
        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            //--- Note: Thread safe
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }
}
