using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficLight light = new TrafficLight(new GreenLight());
            light.Lighting();
            light.Lighting();
            light.Lighting();
            light.Lighting();
            light.Lighting();
            light.Lighting();
            light.Lighting();
            light.Lighting();
            light.Lighting();

            Console.ReadLine();
        }
    }

    public abstract class LightState
    {
        public abstract void Lighting(TrafficLight light);
    }

    public class TrafficLight
    {
        public LightState _state;

        public TrafficLight(LightState state)
        {
            _state = state;
        }

        public void Lighting()
        {
            _state.Lighting(this);
        }

        public void ChangeState(LightState state)
        {
            _state = state;
        }
    }

    public class RedLight : LightState
    {
        public override void Lighting(TrafficLight light)
        {
            Console.WriteLine("red light is lighting");
            light.ChangeState(new GreenLight());
        }
    }

    public class GreenLight : LightState
    {
        public override void Lighting(TrafficLight light)
        {
            Console.WriteLine("green light is lighting");
            light.ChangeState(new YellowLight());
        }
    }

    public class YellowLight : LightState
    {
        public override void Lighting(TrafficLight light)
        {
            Console.WriteLine("yellow light is lighting");
            light.ChangeState(new RedLight());
        }
    }
}
