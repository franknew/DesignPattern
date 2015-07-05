using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ProtoType
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = new TestClass();
            SubClass son = new SubClass();
            son.s = "subclass";
            test.a = "a1";
            test.b = 10;
            test.son = son;
            TestClass test1 = test.Clone<TestClass>();
            Console.WriteLine("copid successfully.");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// use class extension class to implement prototype
    /// </summary>
    public static class Object
    {
        /// <summary>
        /// using reflection to extend clone method to objects. copy properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T Clone<T>(this object o)
        {
            T data = System.Activator.CreateInstance<T>();
            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                PropertyInfo temp = data.GetType().GetProperty(property.Name);
                temp.SetValue(data, property.GetValue(o, null), null);
                Console.WriteLine("CopidProperty -- " + property.Name + ":" + property.GetValue(o, null));
            }
            return data;
        }
    }

    public class TestClass
    {
        public string a { get; set; }
        public int b { get; set; }
        public SubClass son { get; set; }
    }

    public class SubClass
    {
        public string s { get; set; }
    }

}
