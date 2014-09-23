using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain = new Chain();
            chain.AddCharger(new Charger1());
            chain.AddCharger(new Charger2());
            chain.AddCharger(new Charger3());

            chain.Charger(ChargeFlag.Charger2).Charger(ChargeFlag.Charger1);
            chain.Charger(ChargeFlag.Charger3);

            Console.ReadLine();
        }
    }

    public class Chain
    {
        private List<ICharger> _chargerList = new List<ICharger>();

        public void AddCharger(ICharger chain)
        {
            _chargerList.Add(chain);
        }

        public Chain Charger(ChargeFlag flag)
        {
            _chargerList.ForEach(t =>
            {
                if (flag == t._chargeLevel)
                {
                    t.DoSomeThing();
                    return;
                }
            });
            return this;
        }
    }

    public abstract class ICharger
    {
        public ChargeFlag _chargeLevel;
        public abstract void DoSomeThing();
    }

    public class Charger1 : ICharger
    {
        public Charger1()
        {
            _chargeLevel = ChargeFlag.Charger1;
        }

        public override void DoSomeThing()
        {
            Console.WriteLine("charger1 is doing something");
        }
    }

    public class Charger2 : ICharger
    {
        public Charger2()
        {
            _chargeLevel = ChargeFlag.Charger2;
        }

        public override void DoSomeThing()
        {
            Console.WriteLine("charger2 is doing something");
        }
    }

    public class Charger3 : ICharger
    {
        public Charger3()
        {
            _chargeLevel = ChargeFlag.Charger3;
        }

        public override void DoSomeThing()
        {
            Console.WriteLine("charger3 is doing something");
        }
    }

    public enum ChargeFlag
    {
        Charger1,
        Charger2,
        Charger3,
    }
}
