using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCharactor a1 = CharactorFactory.CreateCharactor('a');
            a1.Display();
            AbstractCharactor a2 = CharactorFactory.CreateCharactor('a');
            a2.Display();
            AbstractCharactor b1 = CharactorFactory.CreateCharactor('b');
            b1.Display();
            AbstractCharactor b2 = CharactorFactory.CreateCharactor('b');
            b2.Display();
            AbstractCharactor b3 = CharactorFactory.CreateCharactor('b');
            b3.Display();
            AbstractCharactor b4 = CharactorFactory.CreateCharactor('b');
            b4.Display();
            AbstractCharactor a3 = CharactorFactory.CreateCharactor('a');
            a3.Display();
            AbstractCharactor a4 = CharactorFactory.CreateCharactor('a');
            a4.Display();
            AbstractCharactor c1 = CharactorFactory.CreateCharactor('c');
            c1.Display();

            Console.ReadLine();
        }
    }

    public abstract class AbstractCharactor
    {
        protected char _letter;

        public void Display()
        {
            Console.WriteLine("hashcode:{0},char:{1}", this.GetHashCode(), _letter);
        }
    }

    public class CharactorA : AbstractCharactor
    {
        public CharactorA()
        {
            base._letter = 'a';
        }
    }

    public class CharactorB : AbstractCharactor
    {
        public CharactorB()
        {
            base._letter = 'b';
        }
    }

    public class CharactorC : AbstractCharactor
    {
        public CharactorC()
        {
            base._letter = 'c';
        }
    }

    public class CharactorD : AbstractCharactor
    {
        public CharactorD()
        {
            base._letter = 'd';
        }
    }

    public class CharactorE : AbstractCharactor
    {
        public CharactorE()
        {
            base._letter = 'e';
        }
    }

    public class CharactorFactory
    {
        private static Dictionary<char, AbstractCharactor> _charactorDic = new Dictionary<char,AbstractCharactor>();

        public static AbstractCharactor CreateCharactor(char charactor)
        {
            AbstractCharactor charactorClass;
            if (_charactorDic.ContainsKey(charactor))
            {
                charactorClass = _charactorDic[charactor] as AbstractCharactor;
            }
            else
            {
                switch (charactor)
                {
                    case 'b':
                        charactorClass = new CharactorB();
                        break;
                    case 'c':
                        charactorClass = new CharactorC();
                        break;
                    case 'd':
                        charactorClass = new CharactorD();
                        break;
                    case 'e':
                        charactorClass = new CharactorE();
                        break;
                    default:
                        charactorClass = new CharactorA();
                        break;
                }
                _charactorDic[charactor] = charactorClass;
            }
            return charactorClass;
        }
    }
}
