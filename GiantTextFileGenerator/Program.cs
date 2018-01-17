using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiantTextFileGenerator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            Console.WriteLine("开始启动线程写入GUID到文件");

            MassOperation operate = new MassOperation() { TaskCount = 10 };
            Task.Factory.StartNew(() => operate.WriteMassDataIntoFile());

            Console.WriteLine("执行主线程任务开始");
            Thread.Sleep(5000);
            Console.WriteLine("执行主线程任务结束");

            Console.WriteLine("使用q退出循环");

            while (Console.ReadLine() != "q")
            {
                Console.WriteLine("输入无效");
            }
            operate.CancelSource.Cancel();
            operate.CloseSW();

            Console.WriteLine("程序结束");
            Console.Read();
        }
    }
}
