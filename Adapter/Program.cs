using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IAdapter adapter220v = new Charger220V();
            adapter220v.Charge();

            IAdapter adpater550v = new Charger550V();
            adpater550v.Charge();

            Console.ReadLine();
        }
    }

    public interface IAdapter
    {
        void Charge();
    }

    public class Eelectric220V
    {
        public void Charge220V()
        {
            Console.WriteLine("my power is 220v");
        }
    }

    public class Eelectric550V
    {
        public void Charge550V()
        {
            Console.WriteLine("my power is 550v");
        }
    }

    public class Charger220V : Eelectric220V, IAdapter
    {
        public void Charge()
        {
            this.Charge220V();
            Console.WriteLine("i am charging power");
        }
    }

    public class Charger550V : Eelectric550V, IAdapter
    {
        public void Charge()
        {
            this.Charge550V();
            Console.WriteLine("i am charging power");
        }
    }
}
