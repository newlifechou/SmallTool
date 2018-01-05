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
            tester.TestWriteRecord();

            Console.Read();
        }
    }
}
