using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleSingleton.Instance.Display();
            //test thread safty
            for (int i = 0; i < 100; i++)
            {
                Thread th = new Thread(new ThreadStart(SimpleSingleton.Instance.Display));
                th.Start();
            }
            Console.ReadLine();
        }
    }
    /// <summary>
    /// only one instance in a process
    /// </summary>
    public class SimpleSingleton
    {
        /// <summary>
        /// when it inits one more time, it would display one more time
        /// </summary>
        static SimpleSingleton()
        {
            Console.WriteLine("init singleton");
        }
        /// <summary>
        /// this is thread safty, default by microsfot
        /// </summary>
        private static readonly SimpleSingleton instance = new SimpleSingleton();

        public static SimpleSingleton Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// sleep to test thread safty
        /// </summary>
        public void Display()
        {
            Thread.Sleep(1000);
            Console.WriteLine("SimpleSingleton");
        }
    }
}
