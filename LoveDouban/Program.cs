using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace LoveDouban
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(DoubanOperation.GetJson);

            Console.WriteLine("主线程运行");
            Console.Read();
        }
    }
}
