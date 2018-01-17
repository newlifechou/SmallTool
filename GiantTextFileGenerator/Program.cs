using System;
using System.Collections.Generic;
using System.Linq;
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
            MassOperation operate = new MassOperation();
            operate.WriteMassDataIntoFile();

            Console.Read();
        }
    }
}
