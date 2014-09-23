using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Test a = new Test();
            a.Run();
            Console.Read();
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Attr : Attribute
    {
        public Attr(string str)
        {
            Console.WriteLine("I am runing");
        }

    }

    [Attr("efg")]
    public class Test : ContextBoundObject
    {
        [Attr("abc")]
        public void Run()
        {
            Console.WriteLine("run");
        }

    }

    public class AOP
    {
        [DllImport("kernel32.dll")]
        public static extern int GetProcAddress(int hwnd, string lpname);
        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandleA(string name);
        [DllImport("kernel32.dll")]
        public static extern int VirtualAllocEx(IntPtr hwnd, int lpaddress, int size, int type, int tect);
        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr hwnd, int baseaddress, string buffer, int nsize, int filewriten);
        [DllImport("kernel32.dll")]
        public static extern int CreateRemoteThread(IntPtr hwnd, int attrib, int size, int address, int par, int flags, int threadid);
    }

    public static class Extension
    {

    }
}
