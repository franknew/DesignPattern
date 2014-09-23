using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();

            atm.AddObserver(new BankObserver(new Bank()));
            atm.AddObserver(new AssistantObserver(new Assistant()));
            atm.AddObserver(new MessageObserver(new Message()));

            atm.ChangeAmount(1000);

            Console.ReadLine();
        }
    }

    public class ATM
    {
        private List<IObserver> _observerList = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observerList.Add(observer);
        }

        public void ChangeAmount(decimal money)
        {
            Console.WriteLine("user get {0}$ from ATM", money);
            _observerList.ForEach(t =>
            {
                t.Update(money);
            });
        }
    }

    public interface IObserver
    {
        void Update(decimal money);
    }

    public class MessageObserver : IObserver
    {
        private Message _message;

        public MessageObserver(Message message)
        {
            _message = message;
        }

        public void Update(decimal money)
        {
            _message.Notify(money);
        }
    }

    public class AssistantObserver : IObserver
    {
        private Assistant _assistant;

        public AssistantObserver(Assistant assistant)
        {
            _assistant = assistant;
        }

        public void Update(decimal money)
        {
            _assistant.Notify(money);
        }
    }

    public class BankObserver : IObserver
    {
        private Bank _bank;

        public BankObserver(Bank bank)
        {
            _bank = bank;
        }

        public void Update(decimal money)
        {
            _bank.ChangeAmount(money);
        }
    }

    public class Bank
    {
        public void ChangeAmount(decimal money)
        {
            Console.WriteLine("reduced money:{0}", money);
        }
    }

    public class Message
    {
        public void Notify(decimal money)
        {
            Console.WriteLine("from message: your money has been telling {0}", money);
        }
    }

    public class Assistant
    {
        public void Notify(decimal money)
        {
            Console.WriteLine("from assistant: your money has been telling {0}", money);
        }
    }

}
