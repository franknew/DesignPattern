using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseCar car = new NomalCar();
            FasterCar fasterCar = new FasterCar();
            NiceCar niceCar = new NiceCar();
            SteadCar steadCar = new SteadCar();
            car = fasterCar.SpeedUp(car);
            car = steadCar.SteadUp(car);
            car = niceCar.BeNice(car);
            Console.WriteLine("faster:{0}, steader:{1}, nicer:{2}", car.speedUp, car.steadUp, car.beNice);

            Console.ReadLine();
        }
    }

    public abstract class BaseCar
    {
        public bool beNice = false;
        public bool speedUp = false;
        public bool steadUp = false;
    }

    public class NomalCar : BaseCar
    {
    }

    public class FasterCar : BaseCar
    {
        public BaseCar SpeedUp(BaseCar car)
        {
            Console.WriteLine("speed up");
            car.speedUp = true;
            return car;
        }
    }

    public class SteadCar : BaseCar
    {
        public BaseCar SteadUp(BaseCar car)
        {
            Console.WriteLine("stead up");
            car.steadUp = true;
            return car;
        }
    }

    public class NiceCar : BaseCar
    {
        public BaseCar BeNice(BaseCar car)
        {
            Console.WriteLine("be nice");
            car.beNice = true;
            return car;
        }
    }
}
