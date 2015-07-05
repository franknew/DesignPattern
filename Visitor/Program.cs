using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Syringe syrige = new Syringe();
            Arm arm = new Arm("张三");
            Hand hand = new Hand("李四");
            Ass ass = new Ass("王五");

            arm.Accept(syrige);
            hand.Accept(syrige);
            ass.Accept(syrige);

            Console.ReadLine();
        }

        //public abstract class HumanBody
        //{
        //    public string name;
        //    public void Accept(IVisitor vistor)
        //    {
        //        vistor.Visit(this);
        //    }
        //}

        public class Arm
        {
            public string ownername;
            public Arm(string name)
            {
                this.ownername = name;
            }
            public void Accept(IVisitor vistor)
            {
                vistor.Visit(this);
            }
        }

        public class Hand
        {
            public string ownername;
            public Hand(string name)
            {
                this.ownername = name;
            }
            public void Accept(IVisitor vistor)
            {
                vistor.Visit(this);
            }
        }

        public class Ass
        {
            public string ownername;
            public Ass(string name)
            {
                this.ownername = name;
            }
            public void Accept(IVisitor vistor)
            {
                vistor.Visit(this);
            }
        }

        public interface IVisitor
        {
            void Visit(Arm arm);

            void Visit(Hand hand);

            void Visit(Ass ass);

            //void Visit(HumanBody body);
        }

        public class Syringe : IVisitor
        {
            public void Visit(Arm arm)
            {
                Console.WriteLine("drug is in {0}'s body through arm", arm.ownername);
            }
            public void Visit(Hand hand)
            {
                Console.WriteLine("drug is in {0}'s body through hand", hand.ownername);
            }
            public void Visit(Ass ass)
            {
                Console.WriteLine("drug is in {0}'s body through ass", ass.ownername);
            }
            //public void Visit(HumanBody body)
            //{
            //    Console.WriteLine("drug is in your body though {0}", body.name);
            //}
        }
    }
}
