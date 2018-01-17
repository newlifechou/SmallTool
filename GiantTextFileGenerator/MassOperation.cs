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
            dataFilePath = Path.Combine(Environment.CurrentDirectory,  "MassData.txt");
        }


        public void WriteMassDataIntoFile()
        {
            var fs = new FileStream(dataFilePath, FileMode.Append);
            var sw = new StreamWriter(fs);
            for (int i = 0; i < 1000; i++)
            {
                Task t = new Task(() =>
                {
                    WriteMsg(sw);
                });
                t.Start();
                t.Wait();
            }
            
            sw.Close();
            fs.Close();
        }

        private void WriteMsg(StreamWriter sw)
        {
            while (true)
            {
                string line = Guid.NewGuid().ToString();
                sw.AutoFlush = true;
                sw.WriteLine($"{Thread.CurrentThread.ManagedThreadId}-{line}");
                Console.WriteLine(line);
            }
        }
    }
}
