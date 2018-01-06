using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCsvLib
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvHelperTest tester = new CsvHelperTest();
            tester.TestWriteWithMapping();
            //tester.TestWriteRecord();




            Console.WriteLine("执行完毕");
            System.Diagnostics.Process.Start(Environment.CurrentDirectory);
            Console.Read();
        }
    }
}
