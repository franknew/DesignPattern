using System;

namespace GangOfFour.Behavioral
{
    //--- Allow an object to alter its behavior when its internal state changes.
    //--- The object will appear to change its class.

    internal static class Usage
    {
        internal static void UsageMethod()
        {
            var context = new Context(new ConcreteStateA());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
    }

    public interface IState
    {
        void Handle(Context context);
    }

    public class ConcreteStateA : IState
    {
        public virtual void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    public class ConcreteStateB : IState
    {
        public virtual void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    public class Context
    {
        private IState state;

        //--- C'tor
        public Context(IState state)
        {
            State = state;
        }

        public IState State
        {
            get { return state; }
            set
            {
                state = value;
                System.Diagnostics.Debug.WriteLine("State: " + state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}
