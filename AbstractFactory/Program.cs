using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory carFactory = new CarFactory();
            AbstractCar car = carFactory.CreateProduct();
            car.Run();

            AbstractFactory busFactory = new BusFactory();
            AbstractCar bus = busFactory.CreateProduct();
            bus.Run();

            Console.Read();
        }
    }

    public interface AbstractFactory
    {
        AbstractCar CreateProduct();
    }

    public class CarFactory : AbstractFactory
    {
        public AbstractCar CreateProduct()
        {
            AbstractCar car = new Car(new CarDoor(), new CarWheel());
            Console.WriteLine("create a car");
            return car;
        }
    }

    public class BusFactory : AbstractFactory
    {
        public AbstractCar CreateProduct()
        {
            AbstractCar bus = new Bus(new BusDoor(), new BusWheel());
            Console.WriteLine("create a bus");
            return bus;
        }
    }

    /// <summary>
    /// abstract of car and bus body, not means only to car.
    /// </summary>
    public abstract class AbstractCar
    {
        public AbstractDoor _door;
        public AbstractWheel _wheel;

        public abstract void Run();
    }

    /// <summary>
    /// car body
    /// </summary>
    public class Car : AbstractCar
    {
        public Car(CarDoor door, CarWheel wheel)
        {
            base._door = door;
            base._wheel = wheel;
        }

        public override void Run()
        {
            Console.WriteLine("car is runing");
        }
    }

    /// <summary>
    /// bus body
    /// </summary>
    public class Bus : AbstractCar
    {
        public Bus(BusDoor door, BusWheel wheel)
        {
            base._door = door;
            base._wheel = wheel;
        }
        public override void Run()
        {
            Console.WriteLine("bus is runing");
        }
    }

    /// <summary>
    /// door
    /// </summary>
    public abstract class AbstractDoor
    {
    }

    public class CarDoor : AbstractDoor
    {
        public CarDoor()
        {
            Console.WriteLine("create a car door");
        }
    }

    public class BusDoor : AbstractDoor
    {
        public BusDoor()
        {
            Console.WriteLine("create a bus door");
        }
    }

    /// <summary>
    /// wheel
    /// </summary>
    public abstract class AbstractWheel
    {
    }

    public class CarWheel : AbstractWheel
    {
        public CarWheel()
        {
            Console.WriteLine("create a car wheel");
        }
    }

    public class BusWheel : AbstractWheel
    {
        public BusWheel()
        {
            Console.WriteLine("create a bus wheel");
        }
    }
}
