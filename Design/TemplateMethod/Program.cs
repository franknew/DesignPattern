using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseScocerPlayer nomalPlayer = new NomalSocerPlayer();
            nomalPlayer.JoinSoccer();

            BaseScocerPlayer starPlayer = new StarSoccerPlayer();
            starPlayer.JoinSoccer();

            Console.ReadLine();
        }
    }

    public abstract class BaseScocerPlayer
    {
        protected abstract void Run();

        protected abstract void Pass();

        protected abstract void Shot();

        protected abstract void Goal();

        public void JoinSoccer()
        {
            this.Run();

            this.Pass();

            this.Shot();

            this.Goal();
        }
    }

    public class NomalSocerPlayer : BaseScocerPlayer
    {
        protected override void Run()
        {
            Console.WriteLine("runing not fast");
        }

        protected override void Pass()
        {
            Console.WriteLine("try to pass over other players");
        }

        protected override void Shot()
        {
            Console.WriteLine("has 30% to goal");
        }

        protected override void Goal()
        {
            Console.WriteLine("good\n");
        }
    }

    public class StarSoccerPlayer : BaseScocerPlayer
    {
        protected override void Run()
        {
            Console.WriteLine("runing very fast");
        }

        protected override void Pass()
        {
            Console.WriteLine("passed over many players");
        }

        protected override void Shot()
        {
            Console.WriteLine("has 70% to goal");
        }

        protected override void Goal()
        {
            Console.WriteLine("perfect\n");
        }
    }
}
