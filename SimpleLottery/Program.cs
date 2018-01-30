using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottery
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new UnrepeatRandomNumber();
            for (int i = 0; i < 5; i++)
            {
                t.GetPartRandomArray(10, 20).ToList().ForEach(k =>
                {
                    Console.Write($"{k} ");
                });
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
