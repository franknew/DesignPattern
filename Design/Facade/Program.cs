using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Expressions;
using System.IO;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "(1.49+3*2)%2";
            double result = Evaluate(str);
            int x = 5;

            Console.WriteLine(result);
            Console.WriteLine(string.Format("{0:0#}", x)); 
            Console.ReadLine();
        }

        public static double Evaluate(string expression)
        {
            return (double)new System.Xml.XPath.XPathDocument
            (new StringReader("<r/>")).CreateNavigator().Evaluate
            (string.Format("number({0})", new
            System.Text.RegularExpressions.Regex(@"([\+\-\*])")
            .Replace(expression, " ${1} ")
            .Replace("/", " div ")
            .Replace("%", " mod ")));
        }
    }

}
