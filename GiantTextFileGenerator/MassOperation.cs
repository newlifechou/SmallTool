using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace GiantTextFileGenerator
{
    class MassOperation
    {
        private string dataFilePath;
        public MassOperation()
        {
            dataFilePath = Path.Combine(Environment.CurrentDirectory, "MassData.txt");
            TaskCount = 100;
            cancelSource = new CancellationTokenSource();
            cancel = cancelSource.Token;
        }

        private StreamWriter sw;
        public int TaskCount { get; set; }

        private CancellationTokenSource cancelSource;
        private CancellationToken cancel;

        public CancellationTokenSource CancelSource
        {
            get
            {
                return cancelSource;
            }
        }
        public void WriteMassDataIntoFile()
        {
            var fs = new FileStream(dataFilePath, FileMode.Append);
            sw = new StreamWriter(fs);

            for (int i = 0; i < TaskCount; i++)
            {
                Task t = new Task(() =>
                {
                    WriteMsg(sw);
                },
                cancel,
                TaskCreationOptions.LongRunning);
                t.Start();
                Console.WriteLine($"启动第{i + 1}个任务");
            }

            Console.WriteLine($"所有的{TaskCount}个任务已经开始执行");

        }

        public void CloseSW()
        {
            sw.Close();
            Console.WriteLine("关闭写入SW对象");
        }

        private void WriteMsg(StreamWriter sw)
        {
            while (true)
            {
                string line = Guid.NewGuid().ToString();
                sw.AutoFlush = true;
                sw.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-{line}");
                Debug.Write("*");
            }
        }
    }
}
