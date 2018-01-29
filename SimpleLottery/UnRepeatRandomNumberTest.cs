using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLottery
{
    class UnRepeatRandomNumberTest
    {
        private UnrepeatRandomNumber myRepeater;
        public UnRepeatRandomNumberTest()
        {
            myRepeater = new UnrepeatRandomNumber();
        }
        public void Test01()
        {
            for (int j = 0; j < 10; j++)
            {
                foreach (var item in myRepeater.GetFullRandomArray(10,20))
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }
    }
}
