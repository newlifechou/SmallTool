using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shibor
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(new ShiborLib().DownloadTask);
            task.Start();

            Console.WriteLine("主程序运行");
            Console.Read();
        }
    }
}
