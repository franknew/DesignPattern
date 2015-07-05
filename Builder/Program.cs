using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Builder
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CarBuilder builder = new CarBuilder();
            Director.BuildCar(builder);
            builder.GetProduct();
            Console.ReadLine();
        }
    }

    public interface AbstractBuilder
    {
        //build car step by step
        void BuildDoor();
        void BuildWheel();
        void BuildSkin();
        //build completed, return your result
        void GetProduct();
    }

    public class CarBuilder : AbstractBuilder
    {
        public void BuildDoor()
        {
            Console.WriteLine("door is built");
        }
        public void BuildWheel()
        {
            Console.WriteLine("wheel is built");
        }
        public void BuildSkin()
        {
            Console.WriteLine("skin is built");
        }

        /// <summary>
        /// return the product
        /// </summary>
        public void GetProduct()
        {
            Console.WriteLine("I built a car");
        }
    }

    /// <summary>
    /// director to build what should be built
    /// </summary>
    public class Director
    {
        /// <summary>
        /// build car logic
        /// </summary>
        /// <param name="builder"></param>
        public static void BuildCar(AbstractBuilder builder)
        {
            builder.BuildDoor();
            builder.BuildWheel();
            builder.BuildSkin();
        }
    }
}
