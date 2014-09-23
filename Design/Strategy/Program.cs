using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            TaxCal tax1 = new TaxCal(new ChinaTax());
            tax1.CalTax();

            TaxCal tax2 = new TaxCal(new USATax());
            tax2.CalTax();

            Console.ReadLine();
        }
    }

    public class TaxCal
    {
        private IStrategy _tax;
        public TaxCal(IStrategy tax)
        {
            _tax = tax;
        }

        public void CalTax()
        {
            _tax.Tax();
        }
    }

    public interface IStrategy
    {
        void Tax();
    }

    public class ChinaTax : IStrategy
    {
        public void Tax()
        {
            Console.WriteLine("run china tax method");
        }
    }

    public class USATax : IStrategy
    {
        public void Tax()
        {
            Console.WriteLine("run USA tax method");
        }
    }
}
