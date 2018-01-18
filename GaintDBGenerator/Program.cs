using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaintDBGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始工作");
            Mass op = new Mass();
            Console.WriteLine("开始写入大量数据到数据库");
            op.TaskWriteData();

            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                //do nothing
            }

            op.CancelSource.Cancel();
            Console.WriteLine("结束写入大量数据到数据库");

            Console.Read();
        }
    }
}
