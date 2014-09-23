using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            MSSQLConnection mssqlcon = new MSSQLConnection();
            MySQLConnection mysqlcon = new MySQLConnection();

            ConnectionProxy proxy = new ConnectionProxy(mssqlcon);
            proxy.Connect();

            proxy._connection = mysqlcon;
            proxy.Connect();

            Console.ReadLine();
        }
    }

    public interface Connection
    {
        void Connect();
    }

    public class MSSQLConnection : Connection
    {
        public void Connect()
        {
            Console.WriteLine("ms sql connected");
        }
    }

    public class MySQLConnection : Connection
    {
        public void Connect()
        {
            Console.WriteLine("my sql connected");
        }
    }
    /// <summary>
    /// proxy class, use the same interface to call proxed object.
    /// </summary>
    public class ConnectionProxy : Connection
    {
        public Connection _connection;
        public ConnectionProxy(Connection connection)
        {
            _connection = connection;
        }

        public void Connect()
        {
            Console.WriteLine("begin connect");
            //call proxed interface
            _connection.Connect();
            Console.WriteLine("end connect\n");
        }
    }
}
