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
            int m, n = 0;
            ThreadPool.GetMaxThreads(out m, out n);
            Debug.Print($"之前{m}-{n}");

            MassOperation operate = new MassOperation();
            Task.Factory.StartNew(() => operate.WriteMassDataIntoFile());

            ThreadPool.GetMaxThreads(out m, out n);

            Thread.Sleep(5000);
            Debug.Print($"之后{m}-{n}");

            Console.Read();
        }
    }
}
