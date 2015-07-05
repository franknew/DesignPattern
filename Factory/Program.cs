using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //delay implement to sub class
            DBHelper helper = DBFactory.CreateHelper(DBType.MSSQL);
            helper.RunSQL("select * from table");
            Console.ReadLine();
        }
    }

    public class DBFactory
    {
        public static DBHelper CreateHelper(DBType type)
        {
            DBHelper helper;
            switch (type)
            {
                case DBType.MySQL:
                    helper = new MySQLHelper();
                    break;
                case DBType.Oracle:
                    helper = new OracleHelper();
                    break;
                default:
                    helper = new MSSQLHelper();
                    break;
            }
            return helper;
        }
    }

    public interface DBHelper
    {
        void RunSQL(string sql);
    }


    public class MSSQLHelper : DBHelper
    {
        public void RunSQL(string sql)
        {
            Console.WriteLine("run ms sql:");
            Console.WriteLine(sql);
        }
    }
    public class MySQLHelper : DBHelper
    {
        public void RunSQL(string sql)
        {
            Console.WriteLine("run my sql:");
            Console.WriteLine(sql);
        }
    }
    public class OracleHelper : DBHelper
    {
        public void RunSQL(string sql)
        {
            Console.WriteLine("run oracle:");
            Console.WriteLine(sql);
        }
    }

    public enum DBType
    {
        MSSQL,
        MySQL,
        Oracle,
    }
}
